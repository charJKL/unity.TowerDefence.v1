using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] float speed = 30f;
	[SerializeField] float border = 20f;
	
	[Flags] enum BorderPosition { None = 0, Top = 1, Right = 2, Bottom = 4, Left = 8}
	const string FOWARD_KEY = "w";
	const string BACK_KEY = "s";
	const string RIGHT_KEY = "d";
	const string LEFT_KEY = "a";
	const string SCROLL_AXIS = "Mouse ScrollWheel";
	
	const float ZOOM_MIN_VALUE = 10f;
	const float ZOOM_MAX_VALUE = 45f;
	
	private void Update()
	{
		BorderPosition mouseOnBorder = GetMouseBorderPosition(Input.mousePosition);
		bool isMoveFoward = Input.GetKey(FOWARD_KEY) || mouseOnBorder.HasFlag(BorderPosition.Top);
		bool isMoveBack = Input.GetKey(BACK_KEY) || mouseOnBorder.HasFlag(BorderPosition.Bottom);
		bool isMoveRight = Input.GetKey(RIGHT_KEY) || mouseOnBorder.HasFlag(BorderPosition.Right);
		bool isMoveLeft =  Input.GetKey(LEFT_KEY) || mouseOnBorder.HasFlag(BorderPosition.Left);
		float isScroll = Input.GetAxis(SCROLL_AXIS);
		
		Vector3 movement = Vector3.zero;
		if(isMoveFoward) movement += Vector3.forward;
		if(isMoveBack) movement += Vector3.back;
		if(isMoveRight) movement += Vector3.right;
		if(isMoveLeft) movement += Vector3.left;
		if(isScroll != 0) movement.y += isScroll * -1 * 100;
		
		Vector3 position = transform.position + movement * speed * Time.deltaTime;
		position.y = Math.Clamp(position.y, ZOOM_MIN_VALUE, ZOOM_MAX_VALUE);
		
		transform.position = position;
	}

	private BorderPosition GetMouseBorderPosition(Vector2 mousePosition)
	{
		// TODO return valid flag only is cursor is inside window, or game have focus? This effect only occur in Unity editor.
		BorderPosition borderPosition = BorderPosition.None;
		if(mousePosition.y > Screen.height - border) borderPosition |= BorderPosition.Top;
		if(mousePosition.x > Screen.width - border) borderPosition |= BorderPosition.Right;
		if(mousePosition.y < border) borderPosition |= BorderPosition.Bottom;
		if(mousePosition.x < border) borderPosition |= BorderPosition.Left;
		
		return borderPosition;
	}
	
}
