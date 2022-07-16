using UnityEngine;

public class TurretShoot : MonoBehaviour
{
	[SerializeField] private Projectile projectile;
	[SerializeField] private Transform barrel;
	[SerializeField] private TurretTargeting targeting;
	
	[SerializeField] private float fireRate = 1f;
	
	private float timer;
	
	private void Update()
	{
		timer += Time.deltaTime;
		if(targeting.Target == null) return;
		if(timer > fireRate) // TODO this logic has bugs, we can shoot so fast that we shoud spawn 2 projectiles in one frame.
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
