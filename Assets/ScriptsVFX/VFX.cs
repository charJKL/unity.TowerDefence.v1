using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class VFX : MonoBehaviour
{
	public void Init(Vector3 position)
	{
		GameObject instance = Instantiate(gameObject, position, Quaternion.identity);
		
		ParticleSystem particleSystem = instance.GetComponent<ParticleSystem>();
		float timeout = Mathf.Max(particleSystem.main.duration, particleSystem.main.startLifetimeMultiplier) + 0.1f;
		Destroy(instance, timeout);
	}
}
