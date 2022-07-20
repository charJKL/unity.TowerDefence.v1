using UnityEngine;



[RequireComponent(typeof(LineRenderer))]
public class ProjectileBeam : MonoBehaviour
{
	[SerializeField] private ParticleSystem vfx;
	[SerializeField] private new GameObject light;
	
	private Transform barrel;
	private Transform target;
	private LineRenderer line;
	
	public Transform Target { get => target; }
	
	private void Awake()
	{
		line = GetComponent<LineRenderer>();
	}
	
	public ProjectileBeam Init(Transform transform)
	{
		GameObject instance = Instantiate(gameObject, transform.position, Quaternion.identity);
		ProjectileBeam projectileBeam = instance.GetComponent<ProjectileBeam>();
		projectileBeam.SetBarrel(transform);
		
		return projectileBeam;
	}
	
	private void Update()
	{
		if(target == null) return;
		line.SetPosition(0, barrel.position);
		line.SetPosition(1, target.position);
		
		Vector3 direction = barrel.position - target.position;
		Vector3 point = target.position + direction.normalized;
		vfx.transform.position = point;
		vfx.transform.rotation = Quaternion.LookRotation(direction);
		
		EnemyHealth enemy = target.GetComponent<EnemyHealth>();
		if(enemy) enemy.TakeDamage(2 * Time.deltaTime);
	}
	
	public void SetBarrel(Transform transform)
	{
		barrel = transform;
	}
	
	public void SetTarget(Transform transform)
	{
		target = transform;
	}
	
	public void Enable()
	{
		gameObject.SetActive(true);
		light.SetActive(true);
		vfx.Play();
	}
	
	public void Disable()
	{
		light.SetActive(false);
		vfx.Stop();
		gameObject.SetActive(false);
	}
}
