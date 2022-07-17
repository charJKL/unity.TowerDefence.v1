using System;
using UnityEngine;

[Serializable]
public struct TurretRecord
{
	[SerializeField] private Turret turret;
	[SerializeField] private float cost;
	
	public Turret Turret { get => turret; }
	public float Cost { get => cost; }
	
}
