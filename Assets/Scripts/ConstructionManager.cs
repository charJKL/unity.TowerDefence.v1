using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
	[SerializeField] private Player player;
	
	private TurretRecord selection;
	
	public Turret GetSelectedTurret()
	{
		return selection.Turret;
	}
	
	public void SelectTurret(TurretRecord turret)
	{
		selection = turret;
	}
	
	public bool IsTurretSelected()
	{
		return selection.Turret != null;
	}
	
	public GameObject Build(Vector3 position)
	{
		if(player.HaveEnoughtMoney(selection.Cost) == false)
		{
			Debug.Log($"You don't have enought money");
			return null;
		}
		player.Buy(-selection.Cost);
		return selection.Turret.Init(position);
	}
}
