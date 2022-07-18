using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretSelectionUi : MonoBehaviour
{
	[Header("References to ui:")]
	[SerializeField] private Image image;
	[SerializeField] private TextMeshProUGUI cost;
	[SerializeField] private Animator insufficientFund;
	
	[Header("Options:")]
	[SerializeField] private Color insufficientColor;
	
	const string INSUFFICIENT_FUND_TRIGGER = "InsufficientFund";
	private Button button;
	private Color idle;
	
	private void Awake()
	{
		idle = image.color;
	}
	
	public void SetCost(float amount)
	{
		cost.SetText($"${amount}");
	}
	
	public void InsufficientFund()
	{
		insufficientFund.SetTrigger(INSUFFICIENT_FUND_TRIGGER);
	}
	
	public void CanAfford(bool canAfford)
	{
		switch(canAfford)
		{
			case true:
				cost.color = Color.black;
				image.color = idle;
				break;
				
			case false:
				cost.color = Color.red;
				image.color = insufficientColor;
				break;
		}
	}
}
