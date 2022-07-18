using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretsUi : MonoBehaviour
{
	[SerializeField] private ConstructionManager constructionManager;
	[SerializeField] private Player player;
	[SerializeField] private TurretRecord turretGun;
	[SerializeField] private TurretRecord turretLauncher;
	
	// TODO this should be some kind of list:
	[SerializeField] private TurretSelectionUi turretGunButton;
	[SerializeField] private TurretSelectionUi turretLauncherButton;
	
	
	public void Start()
	{
		player.OnMoneyChanged += CheckMoneyCosts;
		
		turretGunButton.SetCost(turretGun.Cost);
		turretLauncherButton.SetCost(turretLauncher.Cost);
		turretGunButton.CanAfford(false);
	}
	
	private void CheckMoneyCosts(float money)
	{
		turretGunButton.CanAfford(turretGun.Cost <= money);
		turretLauncherButton.CanAfford(turretLauncher.Cost <= money);
	}
	
	public void SelectTurretGun()
	{
		if(turretGun.Cost > player.Money)
		{
			turretGunButton.InsufficientFund();
			return;
		}
		constructionManager.SelectTurret(turretGun);
	}
	
	public void SelectTurretLauncher()
	{
		if(turretLauncher.Cost > player.Money)
		{
			turretLauncherButton.InsufficientFund();
			return;
		}
		constructionManager.SelectTurret(turretLauncher);
	}
}
