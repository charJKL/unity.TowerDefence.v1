using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
	[SerializeField] private float range = 15f;
	[SerializeField] private float speed = 5f;
	
	public float Range { get => range; }
	
	const string ENEMY_TAG = "Enemy";
	private Transform target;
	
	private void Start()
	{
		target = null;
		InvokeRepeating("FindTarget", 0f, .5f);
	}
	
	private void Update()
	{
		if(target == null) return;
		
		Vector3 direction = target.position - transform.position;
		Vector3 rotationAroundYAxis = new Vector3(direction.x, 0, direction.z);
		Quaternion lookRotation = Quaternion.LookRotation(rotationAroundYAxis);
		Quaternion lookAngleToMove = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * speed);
		transform.rotation = lookAngleToMove;
	}
	
	private void FindTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(ENEMY_TAG);
		(GameObject enemy, float distance) = FindNearestEnemy(enemies);
		target = (enemy != null && distance < range) ? enemy.transform : null;
	}
	
	private (GameObject, float) FindNearestEnemy(GameObject[] enemies)
	{
		(GameObject, float) nearest = (null, Mathf.Infinity);
		
		foreach(GameObject enemy in enemies)
		{
			float distance = Vector3.Distance(transform.position, enemy.transform.position);
			if(distance < nearest.Item2)
			{
				nearest.Item1 = enemy;
				nearest.Item2 = distance;
			}
		}
		return nearest;
	}
}
