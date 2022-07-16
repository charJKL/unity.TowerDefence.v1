using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
	[SerializeField] private Projectile projectile;
	[SerializeField] private float speed = 10f;
	[SerializeField] private ParticleSystem crash;
	[SerializeField] private new MeshRenderer renderer;
	
	private bool isDestroyed = false;
	
	private void Update()
	{
		Transform target = projectile.Target;
		
		if(isDestroyed == true) return;
		if(target == null)
		{
			Destroy(gameObject);
			return;
		}
		
		
		Vector3 direction = target.position - transform.position;
		float distance = speed * Time.deltaTime;
		if(direction.magnitude < distance) // TODO why do not use physic collision?
		{
			HitTarget(target.gameObject);
			return;
		}
		transform.Translate(direction.normalized * distance, Space.World); // TODO movement should be done in FixedUpdate
	}
	
	private void HitTarget(GameObject target)
	{
		Debug.Log($"We hit {target.name}");
		crash.Play();
		isDestroyed = true;
		renderer.enabled = false;
		Destroy(gameObject, crash.main.startLifetime.constant); // delay destroy until particle system ends.
	}
}
