using UnityEngine;

[RequireComponent(typeof(Turret))]
[RequireComponent(typeof(TurretTargeting))]
public class TurretShootingProjectile : MonoBehaviour
{
	[SerializeField] private Projectile projectile;
	[SerializeField] private Transform barrel;
	
	private Turret turret;
	private TurretTargeting targeting;
	private float timeout;
	
	private void Awake()
	{
		turret = GetComponent<Turret>();
		targeting = GetComponent<TurretTargeting>();
	}
	
	private void Update()
	{
		timeout -= Time.deltaTime;
		if(targeting.Target == null) return;
		if(timeout <= 0)
		{
			Shoot(targeting.Target.transform);
			timeout = turret.ShootingRate;
		}
	}
	
	private void Shoot(Transform target)
	{
		projectile.Init(barrel.position, target);
	}
}
