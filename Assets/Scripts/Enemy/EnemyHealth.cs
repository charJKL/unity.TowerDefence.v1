using System;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
	private Enemy enemy;
	
	public Action OnDeath;
	public Action<float> OnHealthChanged;
	
	private void Awake()
	{
		enemy = GetComponent<Enemy>();
	}
	
	public void TakeDamage(float damage)
	{
		enemy.Health = Mathf.Clamp(enemy.Health - damage, 0, enemy.MaxHealth);
		OnHealthChanged?.Invoke(enemy.Health);
		if(enemy.Health <= 0) Death();
	}
	
	private void Death()
	{
		OnDeath?.Invoke();
		Destroy(gameObject);
	}
}
