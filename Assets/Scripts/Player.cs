using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("References:")]
	[SerializeField] private StatusUi statusUi;
	
	[Header("Options:")]
	[SerializeField] private float startMoney = 150;
	[SerializeField] private float money;
	
	public Action<float> OnMoneyChanged;
	public float Money { get => money; }
	
	private void Start()
	{
		OnMoneyChanged += (amount) => statusUi.SetMoney(amount);
		SetMoney(startMoney);
	}

	private void SetMoney(float amount)
	{
		money += amount;
		OnMoneyChanged?.Invoke(money);
	}
	
	public bool HaveEnoughtMoney(float amount)
	{
		return amount <= money;
	}

	public void Buy(float amount)
	{
		SetMoney(amount);
	}
}
