using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float startMoney = 500;
	[SerializeField] private float money;
	
	private void Start()
	{
		money = startMoney;
	}

	public bool HaveEnoughtMoney(float amount)
	{
		return amount <= money;
	}
	
	public void Buy(float amount)
	{
		money -= amount;
	}

}
