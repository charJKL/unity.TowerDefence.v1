using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretSelectionUi : MonoBehaviour
{
	[Header("References to ui:")]
	[SerializeField] private Image image;
	[SerializeField] private Image costPanel;
	[SerializeField] private TextMeshProUGUI costText;
	[SerializeField] private Image selected;
	[SerializeField] private Animator insufficientFund;
	
	[Header("Options:")]
	[SerializeField] private Color insufficientColor;
	
	const string INSUFFICIENT_FUND_TRIGGER = "InsufficientFund";
	private Button button;
	private Color imageIdleColor;
	private Color costPanelIdleColor;
	
	private void Awake()
	{
		imageIdleColor = image.color;
		costPanelIdleColor = costPanel.color;
	}
	
	public void SetCost(float amount)
	{
		costText.SetText($"${amount}");
	}
	
	public void InsufficientFund()
	{
		insufficientFund.SetTrigger(INSUFFICIENT_FUND_TRIGGER);
	}
	
	public void CanAfford(bool canAfford)
	{
		image.color = canAfford ? imageIdleColor : insufficientColor;
		costPanel.color = canAfford ? costPanelIdleColor : insufficientColor;
	}
	
	public void IsSelected(bool isSelected)
	{
		selected.gameObject.SetActive(isSelected);
	}
}
