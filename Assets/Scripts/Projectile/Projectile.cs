using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private Transform target;
	
	public Transform Target { get => target; }
	
	public void Init(Vector3 position, Transform target)
	{
		Projectile projectile = Instantiate(gameObject, position, Quaternion.identity).GetComponent<Projectile>();
		projectile.SetTarget(target);
	}
	
	public void SetTarget(Transform transform)
	{
		target = transform;
	}
}
