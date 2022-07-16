using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeHoverIndicator : MonoBehaviour
{
	[SerializeField] private new Renderer renderer;
	[SerializeField] private Material hover;
	
	private Material idle;
	
	private void Awake()
	{
		idle = renderer.material;
	}
	
	private void OnMouseEnter()
	{
		if(EventSystem.current.IsPointerOverGameObject()) return; // TODO this is ugly hack, and buggy. // TODO also name is misleading https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.EventSystem.html
		
		// TODO it's very hard to hover node if something is build on it.
		renderer.material = hover;
	}
	
	private void OnMouseExit()
	{
		renderer.material = idle;
	}
}
