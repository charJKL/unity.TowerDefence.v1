using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public void Init(Vector3 position, Waypoints waypoints)
	{
		GameObject enemy = Instantiate(gameObject, position, Quaternion.identity);
		
		EnemyFollowWaypoints enemyFollowWaypoints = enemy.GetComponent<EnemyFollowWaypoints>();
		enemyFollowWaypoints.SetWaypoints(waypoints);
	}
}
