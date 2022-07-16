using UnityEngine;

[RequireComponent(typeof(Turret))]
[RequireComponent(typeof(TurretTargeting))]
public class TurretShooting : MonoBehaviour
{
	[SerializeField] private Projectile projectile;
	[SerializeField] private Transform barrel;
	
	private Turret turret;
	private TurretTargeting targeting;
	private float timer;
	
	private void Awake()
	{
		turret = GetComponent<Turret>();
		targeting = GetComponent<TurretTargeting>();
	}
	
	private void Update()
	{
		timer += Time.deltaTime;
		if(targeting.Target == null) return;
		if(timer > turret.ShootintRate) // TODO this logic has bugs, we can shoot so fast that we shoud spawn 2 projectiles in one frame.
		{
			Shoot(targeting.Target.transform);
			timer = 0;
		}
	}
	
	private void Shoot(Transform target)
	{
		projectile.Init(barrel.position, target);
	}
}
