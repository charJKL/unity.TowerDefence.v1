using UnityEngine;

[RequireComponent(typeof(Turret))]
[RequireComponent(typeof(TurretTargeting))]
public class TurretShootingBeam : MonoBehaviour
{
	[SerializeField] private ProjectileBeam projectileBeam;
	[SerializeField] private Transform barrel;
	
	private Turret turret;
	private TurretTargeting targeting;
	private ProjectileBeam beam;
	private float timeoutDuration;
	private bool isOverheated = false;
	private bool isBeamEnabled = false;
	
	
	private void Awake()
	{
		turret = GetComponent<Turret>();
		targeting = GetComponent<TurretTargeting>();
		beam = projectileBeam.Init(barrel);
	}
	
	private void Start()
	{
		timeoutDuration = turret.ShootingDuration;
		EnableOverheated();
	}
	
	private void Update()
	{
		if(isBeamEnabled) timeoutDuration = Mathf.Clamp(timeoutDuration - Time.deltaTime, 0, turret.ShootingDuration);
		else timeoutDuration = Mathf.Clamp(timeoutDuration + Time.deltaTime, 0, turret.ShootingDuration);
		
		if(isOverheated == false && timeoutDuration > 0.1 && targeting.Target) EnableBeam(targeting.Target);
		if(targeting.Target == null) DisableBeam();
		if(timeoutDuration <= 0) 
		{
			DisableBeam();
			EnableOverheated();
		}
	}
	
	private void EnableOverheated()
	{
		isOverheated = true;
		Invoke("DisableOverheated", 3f);
	}
	
	private void DisableOverheated()
	{
		isOverheated = false;
	}
	
	private void EnableBeam(Transform target)
	{
		isBeamEnabled = true;
		beam.SetTarget(target);
		beam.Enable();
	}
	
	private void DisableBeam()
	{
		isBeamEnabled = false;
		beam.Disable();
	}
}
