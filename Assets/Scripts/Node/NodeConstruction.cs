using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeConstruction : MonoBehaviour
{
	[SerializeField] private GameObject construction;
	[SerializeField] private Transform basement;
	[SerializeField] private Turret turret;
	
	void OnMouseDown()
	{
		if(construction != null)
		{
			Debug.Log("Something is already build here");
			return;
		}
		
		construction = turret.Init(basement.position);
	}
}
