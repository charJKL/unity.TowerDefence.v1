using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
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
		return selection.Turret.Init(position);
	}
}
