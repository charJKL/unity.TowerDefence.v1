using UnityEngine;

public class Turret : MonoBehaviour
{
	[SerializeField] private float range = 10f;
	[SerializeField] private float shootingRate = 1f;
	[SerializeField] private float shootingDuration = 1f;
	
	public float Range { get => range; }
	public float ShootingRate { get => shootingRate; }
	public float ShootingDuration { get => shootingDuration; }
	
	public GameObject Init(Vector3 position)
	{
		return Instantiate(gameObject, position, Quaternion.identity);
	}
}
