using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	public GameObject Init(Vector3 position)
	{
		return Instantiate(gameObject, position, Quaternion.identity);
	}
}
