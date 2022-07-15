using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
	[SerializeField] private Transform[] points;
	
	public int Count { get => points.Length; }
	
	public Transform GetWaypoint(int index)
	{
		return (index >= points.Length) ? null : points[index];
	}
}
