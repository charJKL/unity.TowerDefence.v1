using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	[SerializeField] private float range = 10f;
	[SerializeField] private float shootintRate = 1f;
	
	public float Range { get => range; }
	public float ShootintRate { get => shootintRate; }
	
	public GameObject Init(Vector3 position)
	{
		return Instantiate(gameObject, position, Quaternion.identity);
	}
}
