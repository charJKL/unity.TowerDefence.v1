using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float maxHealth;
	[SerializeField] private float currentHealth;
	[SerializeField] private float speed;
	
	public float Speed { get => speed; }
	public float Health { get => currentHealth; }
	
	public GameObject Init(Vector3 position, Waypoints waypoints)
	{
		GameObject instance = Instantiate(gameObject, position, Quaternion.identity);
		
		EnemyFollowWaypoints enemyFollowWaypoints = instance.GetComponent<EnemyFollowWaypoints>();
		enemyFollowWaypoints.SetWaypoints(waypoints);
		
		return instance;
	}
	
	public void Start()
	{
		currentHealth = maxHealth;
	}
}
