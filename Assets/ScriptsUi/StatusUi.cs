using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusUi : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI moneyText;
	
	public void SetMoney(float amount)
	{
		moneyText.SetText($"Money: {amount}");
	}
}
