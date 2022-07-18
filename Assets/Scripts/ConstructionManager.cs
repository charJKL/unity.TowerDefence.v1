using System;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
	[SerializeField] private Player player;
	
	private TurretRecord selection;
	public Action<TurretRecord> OnInsufficientFund;
	public Action<TurretRecord> OnSelectionChanged;
	
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
		player.Buy(-selection.Cost);
		return selection.Turret.Init(position);
	}
}
