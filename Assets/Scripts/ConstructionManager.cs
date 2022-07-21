using System;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private uiTurret uiTurret;
	[SerializeField] private NodeInteraction[] nodes;
	
	private TurretRecord selection;
	public Action<TurretRecord> OnInsufficientFund;
	public Action<TurretRecord> OnSelectionChanged;
	
	private void Awake()
	{
		nodes = FindObjectsOfType<NodeInteraction>();
	}
	
	private void Start()
	{
		Array.ForEach(nodes, (node) => node.OnEnter += HighlightNode);
	}
	
	private void HighlightNode(NodeInteraction node)
	{
		if(selection.Turret == null) return;
		node.Highlight();
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
	
	public bool IsTurretSelected()
	{
		return selection.Turret != null;
	}
	
	public GameObject Build(Vector3 position)
	{
		if(player.HaveEnoughtMoney(selection.Cost) == false)
		{
			OnInsufficientFund?.Invoke(selection);
			return null;
		}
		player.Buy(selection.Cost);
		return selection.Turret.Init(position);
	}
}
