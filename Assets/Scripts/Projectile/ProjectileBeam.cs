using UnityEngine;

public class Debug2
{
	static public void Point(Vector3 position)
	{
		Vector3 start = position + Vector3.up;
		Debug.DrawLine(start, position, Color.red, 5f);
	}
	
	static public void Direction(Vector3 position, Vector3 direction)
	{
		Vector3 end = position + direction.normalized;
		Vector3 mark = end + Vector3.up * .5f;
		Debug.DrawLine(position, end, Color.red, 5f);
		Debug.DrawLine(mark, end, Color.red, 5f);
	}
	
}

[RequireComponent(typeof(LineRenderer))]
public class ProjectileBeam : MonoBehaviour
{
	[SerializeField] private ParticleSystem vfx;
	
	private Transform barrel;
	private Transform target;
	private LineRenderer line;
	
	public Transform Target { get => target; }
	
	private void Awake()
	{
		line = GetComponent<LineRenderer>();
		vfx.Play();
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
		line.SetPosition(0, barrel.position);
		line.SetPosition(1, target.position);
		
		Vector3 direction = barrel.position - target.position;
		Vector3 point = target.position + direction.normalized;
		vfx.transform.position = point;
		vfx.transform.rotation = Quaternion.LookRotation(direction);
		Debug2.Point(point);
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
		
	}
	
	public void Disable()
	{
		gameObject.SetActive(false);
		//vfx.Stop();
	}
}
