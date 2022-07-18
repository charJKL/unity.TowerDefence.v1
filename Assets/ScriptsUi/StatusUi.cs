using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusUi : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI livesText;
	[SerializeField] private TextMeshProUGUI moneyText;
	
	public void SetLives(int lives)
	{
		livesText.SetText($"Lives: {lives}");
	}
	
	public void SetMoney(float amount)
	{
		moneyText.SetText($"Money: {amount}");
	}
}
