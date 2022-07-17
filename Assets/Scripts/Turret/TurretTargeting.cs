using UnityEngine;

[RequireComponent(typeof(Turret))]
public class TurretTargeting : MonoBehaviour
{
	[SerializeField] private Transform head;
	
	const string ENEMY_TAG = "Enemy";
	private Turret turret;
	private Transform target;
	private float rotateSpeed = 10f;
	
	public Transform Target { get => target; }
	
	private void Awake()
	{
		turret = GetComponent<Turret>();
	}
	
	private void Start()
	{
		target = null;
		InvokeRepeating("FindTarget", 0f, .5f);
	}
	
	private void Update()
	{
		if(target == null) return;
		
		Vector3 direction = target.position - head.position;
		Vector3 rotationAroundYAxis = new Vector3(direction.x, 0, direction.z);
		Quaternion lookRotation = Quaternion.LookRotation(rotationAroundYAxis);
		Quaternion lookAngleToMove = Quaternion.Lerp(head.rotation, lookRotation, Time.deltaTime * rotateSpeed);
		head.rotation = lookAngleToMove;
	}
	
	private void FindTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(ENEMY_TAG);
		(GameObject enemy, float distance) = FindNearestEnemy(enemies);
		target = (enemy != null && distance < turret.Range) ? enemy.transform : null;
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
