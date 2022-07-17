using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private float range;
	
	private Transform target;
	
	public float Speed { get => speed; }
	public float Range { get => range; }
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
