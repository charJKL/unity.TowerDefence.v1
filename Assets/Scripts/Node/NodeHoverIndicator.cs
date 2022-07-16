using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		// TODO it's very hard to hover node if something is build on it.
		renderer.material = hover;
	}
	
	private void OnMouseExit()
	{
		renderer.material = idle;
	}
}
