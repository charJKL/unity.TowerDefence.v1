using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRangeGizmo : MonoBehaviour
{
	[SerializeField] private TurretTargeting turretTargeting;
	
 	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, turretTargeting.Range); 
	}
}
