using UnityEngine;

public class Debug2
{
	static public void Point(Vector3 position)
	{
		Vector3 start = position + Vector3.up;
		Debug.DrawLine(start, position, Color.red, 5f);
	}
	
	static public void Direction(Vector3 position, Vector3 direction)
	{
		Vector3 end = position + direction.normalized;
		Vector3 mark = end + Vector3.up * .5f;
		Debug.DrawLine(position, end, Color.red, 5f);
		Debug.DrawLine(mark, end, Color.red, 5f);
	}
}
