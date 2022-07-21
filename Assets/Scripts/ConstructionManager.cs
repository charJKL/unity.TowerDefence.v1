using System;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private uiTurret uiTurret;
	[SerializeField] private NodeInteraction[] nodes;
	[SerializeField] private List<Turret> turrets;
	
	private List<Tuple<Node, Turret>> constructions;
	private TurretRecord blueprint;
	public Action<TurretRecord> OnInsufficientFund;
	public Action<TurretRecord> OnSelectionChanged;
	
	private void Awake()
	{
		nodes = FindObjectsOfType<NodeInteraction>();
	}
	
	private void Start()
	{
		constructions = new List<Tuple<Node,Turret>>();
		Array.ForEach(nodes, (node) => 
		{
			node.OnEnter += HighlightNodeForHover;
			node.OnClicked += TryBuildTurret;
		});
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
		BuildTurret(node, blueprint.Turret);
	}
	
	private void SelectTurret(TurretInteraction turretInteraction)
	{
		Debug.Log("Select turret");
		// open dialog box
	}
	
	private Turret BuildTurret(Node node, Turret type)
	{
		GameObject instance = type.Init(node.Basement.position);
		
		TurretInteraction turretInteraction = instance.GetComponent<TurretInteraction>();
		turretInteraction.OnSelected += SelectTurret;
		turretInteraction.OnEnter += HighlightNodeForSelect;
		turretInteraction.OnEnter += HighlightTurretForSelect;
		turretInteraction.OnExit += FadeNodeForSelect;
		
		Turret turret = instance.GetComponent<Turret>();
		constructions.Add(new Tuple<Node, Turret>(node, turret));
		turrets.Add(turret);
		return turret;
	}
	
	private void HighlightNodeForHover(NodeInteraction nodeInteraction)
	{
		if(blueprint.Turret == null) return;
		Node node = nodeInteraction.GetComponent<Node>();
		if(IsNodeEmpty(node) == false) return;
		nodeInteraction.HighlightForHover();
	}
	
	private void HighlightNodeForSelect(TurretInteraction turretInteraction)
	{
		Turret turret = turretInteraction.GetComponent<Turret>();
		Node node = GetNodeForTurret(turret);
		if(node == null) return;
		NodeInteraction nodeInteraction = node.GetComponent<NodeInteraction>();
		nodeInteraction.HighlightForSelect();
	}
	
	private void FadeNodeForSelect(TurretInteraction turretInteraction)
	{
		Turret turret = turretInteraction.GetComponent<Turret>();
		Node node = GetNodeForTurret(turret);
		if(node == null) return;
		turretInteraction.Fade();
		NodeInteraction nodeInteraction = node.GetComponent<NodeInteraction>();
		nodeInteraction.FadeToIdle();
	}
	
	private void HighlightTurretForSelect(TurretInteraction turretInteraction)
	{
		turretInteraction.Highlight();
	}

	private bool IsNodeEmpty(Node node)
	{
		return constructions.Find(link => link.Item1 == node)?.Item2 == null;
	}
	
	private Node GetNodeForTurret(Turret turret)
	{
		return constructions.Find(link => link.Item2 == turret).Item1;
	}
	
	public void SelectBlueprint(TurretRecord turretRecord) // TODO refactor this to match naming changes
	{
		blueprint = turretRecord;
		OnSelectionChanged?.Invoke(turretRecord); 
	}
	
}
