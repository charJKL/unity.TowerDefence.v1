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
	[SerializeField] private TurretRecord turretLaser;
	
	// TODO this should be some kind of list:
	[SerializeField] private TurretSelectionUi turretGunButton;
	[SerializeField] private TurretSelectionUi turretLauncherButton;
	[SerializeField] private TurretSelectionUi turretLaserButton;
	
	public void Start()
	{
		player.OnMoneyChanged += CheckMoneyCosts;
		constructionManager.OnInsufficientFund += HighlightInsufficientFund;
		constructionManager.OnSelectionChanged += HighlightCurrentSelection;
		
		turretGunButton.SetCost(turretGun.Cost);
		turretLauncherButton.SetCost(turretLauncher.Cost);
		turretLaserButton.SetCost(turretLaser.Cost);
	}
	
	public void SelectTurretGun()
	{
		if(turretGun.Cost > player.Money)
		{
			turretGunButton.InsufficientFund();
			return;
		}
		constructionManager.SelectBlueprint(turretGun);
	}
	
	public void SelectTurretLauncher()
	{
		if(turretLauncher.Cost > player.Money)
		{
			turretLauncherButton.InsufficientFund();
			return;
		}
		constructionManager.SelectBlueprint(turretLauncher);
	}
	
	public void SelectTurretLaser()
	{
		if(turretLaser.Cost > player.Money)
		{
			turretLaserButton.InsufficientFund();
			return;
		}
		constructionManager.SelectBlueprint(turretLaser);
	}
	
	private void CheckMoneyCosts(float money)
	{
		turretGunButton.CanAfford(turretGun.Cost <= money);
		turretLauncherButton.CanAfford(turretLauncher.Cost <= money);
		turretLaserButton.CanAfford(turretLaser.Cost <= money);
	}
	
	private void HighlightInsufficientFund(TurretRecord turretRecord)
	{
		if(turretRecord.Turret == turretGun.Turret) turretGunButton.InsufficientFund();
		if(turretRecord.Turret == turretLauncher.Turret) turretLauncherButton.InsufficientFund();
		if(turretRecord.Turret == turretLaser.Turret) turretLaserButton.InsufficientFund();
	}
	
	private void HighlightCurrentSelection(TurretRecord turretRecord)
	{
		turretGunButton.IsSelected(turretRecord.Turret == turretGun.Turret);
		turretLauncherButton.IsSelected(turretRecord.Turret == turretLauncher.Turret);
		turretLaserButton.IsSelected(turretRecord.Turret == turretLaser.Turret);
	}
}
