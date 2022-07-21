using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretInteraction : MonoBehaviour
{
	[SerializeField] public Texture2D cursorTexture;
	
	public Action<TurretInteraction> OnSelected;
	public Action<TurretInteraction> OnEnter;
	public Action<TurretInteraction> OnExit;
	
	public void Highlight()
	{
		Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
	}
	
	public void Fade()
	{
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
	
	private void OnMouseDown()
	{
		if(EventSystem.current.IsPointerOverGameObject()) return; // TODO this is ugly hack. // TODO also name is misleading https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.EventSystem.html
		OnSelected?.Invoke(this);
	}
	
	private void OnMouseEnter()
	{
		if(EventSystem.current.IsPointerOverGameObject()) return; // TODO this is ugly hack, and buggy. // TODO also name is misleading https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.EventSystem.html
		OnEnter?.Invoke(this);
	}
	
	private void OnMouseExit()
	{
		if(EventSystem.current.IsPointerOverGameObject()) return; // TODO this is ugly hack, and buggy. // TODO also name is misleading https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.EventSystem.html
		OnExit?.Invoke(this);
	}
}
