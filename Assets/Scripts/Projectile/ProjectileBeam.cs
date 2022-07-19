using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ProjectileBeam : MonoBehaviour
{
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
		line.SetPosition(0, barrel.position);
		line.SetPosition(1, target.position);
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
	}
}
