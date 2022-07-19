using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class ProjectileExplosion : MonoBehaviour
{
	[SerializeField] private GameObject explosion;
	
	const int LAYER_ENEMY = 1 << 6;
	private Projectile projectile;
	private new Collider collider;
	
	private void Awake()
	{
		projectile = GetComponent<Projectile>();
		collider = GetComponent<Collider>();
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.transform == projectile.Target)
		{
			if(explosion) Instantiate(explosion, transform.position, Quaternion.identity);
			Collider[] colliders = Physics.OverlapSphere(other.transform.position, projectile.Range, LAYER_ENEMY);
			foreach(Collider collider in colliders)
			{
				EnemyHealth enemy = collider.GetComponent<EnemyHealth>();
				if(enemy == null) continue;
				enemy.TakeDamage(150);
			}
			Destroy(gameObject);
		}
	}
}
