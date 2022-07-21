using System;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private uiTurret uiTurret;
	[SerializeField] private NodeInteraction[] nodes;
	
	private Dictionary<Node, GameObject> turrets;
	private TurretRecord selection;
	public Action<TurretRecord> OnInsufficientFund;
	public Action<TurretRecord> OnSelectionChanged;
	
	private void Awake()
	{
		nodes = FindObjectsOfType<NodeInteraction>();
	}
	
	private void Start()
	{
		turrets = new Dictionary<Node, GameObject>();
		Array.ForEach(nodes, (node) => 
		{
			node.OnEnter += HighlightNode;
			node.OnClicked += TryBuildTurret;
		});
	}
	
	private void HighlightNode(NodeInteraction nodeInteraction)
	{
		if(selection.Turret == null) return;
		nodeInteraction.Highlight();
	}
	
	private void TryBuildTurret(NodeInteraction nodeInteraction)
	{
		if(selection.Turret == null) return;
		
		if(player.HaveEnoughtMoney(selection.Cost) == false)
		{
			OnInsufficientFund?.Invoke(selection);
			return;
		}
		Node node = nodeInteraction.GetComponent<Node>();
		if(IsNodeEmpty(node) == false)
		{
			Debug.Log("Something is already build here");
			return;
		}
		
		player.Buy(selection.Cost);
		GameObject turret = selection.Turret.Init(node.Basement.position);
		turrets.Add(node, turret);
	}
	
	public Turret GetSelectedTurret()
	{
		return selection.Turret;
	}
	
	public void SelectTurret(TurretRecord turretRecord)
	{
		selection = turretRecord;
		OnSelectionChanged?.Invoke(turretRecord);
	}
	
	private bool IsNodeEmpty(Node node)
	{
		return turrets.ContainsKey(node) == false;
	}
	
	public bool IsTurretSelected()
	{
		return selection.Turret != null;
	}
}
