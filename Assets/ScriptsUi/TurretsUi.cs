using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsUi : MonoBehaviour
{
	[SerializeField] private ConstructionManager constructionManager;
	[SerializeField] private Turret turretGun;
	[SerializeField] private Turret turretLauncher;
	
	
	public void SelectTurretGun()
	{
		constructionManager.SelectTurret(turretGun);
	}
	
	public void SelectTurretLauncher()
	{
		constructionManager.SelectTurret(turretLauncher);
	}
}
