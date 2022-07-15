using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRangeGizmo : MonoBehaviour
{
	[SerializeField] private TurretShoot turretShoot;
	
 	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, turretShoot.Range); 
	}
}
