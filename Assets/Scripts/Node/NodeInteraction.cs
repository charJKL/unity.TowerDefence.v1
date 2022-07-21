using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Node))]
public class NodeInteraction : MonoBehaviour
{
	[SerializeField] private Material highlightMaterial;
	
	private new Renderer renderer;
	private Node node;
	private Material idleMaterial;
	
	public Action<NodeInteraction> OnClicked;
	public Action<NodeInteraction> OnEnter;
	
	private void Awake()
	{
		renderer = GetComponent<Renderer>();
		node = GetComponent<Node>();
		idleMaterial = renderer.material;
	}
	
	public void Highlight()
	{
		renderer.material = highlightMaterial;
	}
	
	private void OnMouseDown()
	{
		if(EventSystem.current.IsPointerOverGameObject()) return; // TODO this is ugly hack. // TODO also name is misleading https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.EventSystem.html
		OnClicked?.Invoke(this);
	}
	
	private void OnMouseEnter()
	{
		if(EventSystem.current.IsPointerOverGameObject()) return; // TODO this is ugly hack, and buggy. // TODO also name is misleading https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.EventSystem.html
		OnEnter?.Invoke(this);
	}
	
	private void OnMouseExit()
	{
		renderer.material = idleMaterial;
	}
}
