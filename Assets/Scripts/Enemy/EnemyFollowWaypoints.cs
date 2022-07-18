using System;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyFollowWaypoints : MonoBehaviour
{
	private Enemy enemy;
	private Waypoints waypoints;
	private int targetIndex;
	private const float ARRIVE_THRESHOLD = 0.5f;
	
	public Action OnArrivedToEnd;
	
	private void Awake()
	{
		enemy = GetComponent<Enemy>();
	}
	
	public void SetWaypoints(Waypoints waypoints)
	{
		this.waypoints = waypoints;
		this.targetIndex = 0;
		gameObject.SetActive(true);
	}
	
	private void Update()
	{
		Transform target = GetTarget();
		if(target == null) return;
		Vector3 direction = GetDirection(transform.position, target.position);
						direction.y = 0; // remove movement in y axis
		transform.Translate(direction.normalized * enemy.Speed * Time.deltaTime);
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
		return (waypoints == null) ? null : waypoints.GetWaypoint(targetIndex);
	}
	
	private void MoveToNextWaypoint()
	{
		targetIndex++;
		if(targetIndex >= waypoints.Count)
		{
			OnArrivedToEnd?.Invoke();
			Destroy(gameObject);
		}
	}
}
