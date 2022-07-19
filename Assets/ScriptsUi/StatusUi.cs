using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusUi : MonoBehaviour
{
	[SerializeField] private LivesUi livesUi;
	[SerializeField] private TextMeshProUGUI moneyText;
	
	public void SetLives(int lives)
	{
		livesUi.SetLives(lives);
	}
	
	public void SetMoney(float amount)
	{
		moneyText.SetText($"Money: ${amount}");
	}
}
