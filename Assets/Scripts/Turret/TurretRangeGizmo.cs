using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Turret))]
public class TurretRangeGizmo : MonoBehaviour
{
	void OnDrawGizmosSelected()
	{
		Turret turret = GetComponent<Turret>();
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, turret.Range);
	}
}
