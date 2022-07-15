using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowWaypoints : MonoBehaviour
{
	[SerializeField] private float speed = 5f;
	[SerializeField] private Waypoints waypoints;
	
	private int targetIndex;
	private const float ARRIVE_THRESHOLD = 0.2f;
	
	private void Start()
	{
		targetIndex = 0;
	}
	
	private void Update()
	{
		Transform target = GetTarget();
		Vector3 direction = GetDirection(transform.position, target.position);
						direction.y = 0; // remove movement in y axis
		transform.Translate(direction * speed * Time.deltaTime);
		
		if(IsTargetReached(transform.position, target.position)) MoveToNextWaypoint();
	}
	
	private Vector3 GetDirection(Vector3 position, Vector3 target)
	{
		return (target - position).normalized;
	}

	private bool IsTargetReached(Vector3 position, Vector3 target)
	{
		position.y = 0;
		target.y = 0;
		return Vector3.Distance(position, target) < ARRIVE_THRESHOLD;
	}
	
	private Transform GetTarget()
	{
		return waypoints.GetWaypoint(targetIndex);
	}
	
	private void MoveToNextWaypoint()
	{
		targetIndex++;
		if(targetIndex >= waypoints.Count)
		{
			Destroy(gameObject);
		}
	}
}
