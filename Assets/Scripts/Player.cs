using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("References:")]
	[SerializeField] private StatusUi statusUi;
	
	[Header("Options:")]
	[SerializeField] private float startMoney = 150;
	[SerializeField] private float money;
	[SerializeField] private int startLives = 5;
	[SerializeField] private int lives;
	
	public Action<float> OnMoneyChanged;
	public Action<int> OnLivesChanged;
	public float Money { get => money; }
	public float Lives { get => lives; }
	
	private void Start()
	{
		OnMoneyChanged += (amount) => statusUi.SetMoney(amount);
		OnLivesChanged += (lives) => statusUi.SetLives(lives);
		SetMoney(startMoney);
		SetLives(startLives);
	}

	private void SetMoney(float money)
	{
		this.money = money;
		OnMoneyChanged?.Invoke(money);
	}
	
	public void SetLives(int lives)
	{
		this.lives += lives;
		OnLivesChanged?.Invoke(this.lives);
	}
	
	public bool HaveEnoughtMoney(float amount)
	{
		return amount <= money;
	}

	public void Buy(float amount)
	{
		SetMoney(money - amount);
	}
	
	public void AddMoney(float amount)
	{
		SetMoney(money + amount);
	}
}
