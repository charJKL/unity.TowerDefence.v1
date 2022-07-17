using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeConstruction : MonoBehaviour
{
	[SerializeField] private ConstructionManager constructionManager;
	[SerializeField] private Transform basement;
	
	private GameObject construction;
	
	void OnMouseDown()
	{
		if(EventSystem.current.IsPointerOverGameObject()) return; // TODO this is ugly hack. // TODO also name is misleading https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.EventSystem.html
		
		if(construction != null)
		{
			Debug.Log("Something is already build here");
			return;
		}

		construction = constructionManager.GetSelectedTurret().Init(basement.position);
	}
}
