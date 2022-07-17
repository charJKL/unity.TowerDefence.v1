using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class ProjectileMovement : MonoBehaviour
{
	private Projectile projectile;
	
	private void Awake()
	{
		projectile = GetComponent<Projectile>();
	}
	
	private void FixedUpdate()
	{
		Transform target = projectile.Target;
		
		if(target == null)
		{
			Destroy(gameObject);
			return;
		}
		
		Vector3 direction = target.position - transform.position;
		transform.Translate(direction.normalized * projectile.Speed * Time.deltaTime, Space.World); // TODO movement should be done in FixedUpdate
		transform.LookAt(target);
	}
}
