using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
	private Turret selection;
	
	public Turret GetSelectedTurret()
	{
		return selection;
	}
	
	public void SelectTurret(Turret turret)
	{
		selection = turret;
	}
}
