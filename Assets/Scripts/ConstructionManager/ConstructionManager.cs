using System;
using System.Collections.Generic;
using UnityEngine;

public partial class ConstructionManager : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private uiTurret uiTurret;
	[SerializeField] private NodeInteraction[] nodes;
	[SerializeField] private List<Turret> turrets;
	
	private ConstructionManagerInteraction constructionManagerInteraction;
	private List<Tuple<Node, Turret>> constructions;
	private TurretRecord blueprint;
	public Action<TurretRecord> OnInsufficientFund;
	public Action<TurretRecord> OnSelectionChanged;
	
	private void Awake()
	{
		constructionManagerInteraction = new ConstructionManagerInteraction(this);
		nodes = FindObjectsOfType<NodeInteraction>();
	}
	
	private void Start()
	{
		constructions = new List<Tuple<Node,Turret>>();
		Array.ForEach(nodes, constructionManagerInteraction.AddEventListenersForNode);
		Array.ForEach(nodes, (node) => node.OnClicked += TryBuildTurret);
	}
	
	private void TryBuildTurret(NodeInteraction nodeInteraction)
	{
		if(blueprint.Turret == null) return;
		
		if(player.HaveEnoughtMoney(blueprint.Cost) == false)
		{
			OnInsufficientFund?.Invoke(blueprint);
			return;
		}
		Node node = nodeInteraction.GetComponent<Node>();
		if(IsNodeEmpty(node) == false)
		{
			Debug.Log("Something is already build here");
			return;
		}
		
		player.Buy(blueprint.Cost);
		Turret turret = ConstructTurret(node, blueprint.Turret);
		constructions.Add(new Tuple<Node, Turret>(node, turret));
		turrets.Add(turret);
	}
	
	private Turret ConstructTurret(Node node, Turret type)
	{
		GameObject instance = type.Init(node.Basement.position);
		
		TurretInteraction turretInteraction = instance.GetComponent<TurretInteraction>();
		constructionManagerInteraction.AddEventListenersForTurret(turretInteraction);
		turretInteraction.OnSelected += SelectTurret;
		
		return instance.GetComponent<Turret>();
	}
	
	private void SelectTurret(TurretInteraction turretInteraction)
	{
		uiTurret.SetPosition(turretInteraction.transform.position);
		uiTurret.Show();
	}
	
	public bool IsNodeEmpty(NodeInteraction nodeInteraction)
	{
		return IsNodeEmpty(nodeInteraction.GetComponent<Node>());
	}
	
	public bool IsNodeEmpty(Node node)
	{
		return constructions.Find(link => link.Item1 == node)?.Item2 == null;
	}
	
	public bool IsBlueprintSelected()
	{
		return blueprint.Turret != null;
	}
	
	public NodeInteraction GetNodeInteractionForTurret(TurretInteraction turret)
	{
		return GetNodeInteractionForTurret(turret.GetComponent<Turret>());
	}
	
	public NodeInteraction GetNodeInteractionForTurret(Turret turret)
	{
		return constructions.Find(link => link.Item2 == turret).Item1.GetComponent<NodeInteraction>();
	}
	
	public void SelectBlueprint(TurretRecord turretRecord) // TODO refactor this to match naming changes
	{
		blueprint = turretRecord;
		OnSelectionChanged?.Invoke(turretRecord); 
	}
}
