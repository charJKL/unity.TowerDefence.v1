using UnityEngine;
using UnityEngine.UI;

public class uiTurret : MonoBehaviour
{
	[SerializeField] private Button uiUpgrade;
	[SerializeField] private Button uiSell;
	
	public Button uiUpgradeButton { get => uiUpgrade; }
	public Button uiSellButton { get => uiSell; }
	
	public void Show()
	{
		gameObject.SetActive(true);
	}
	
	public void Hide()
	{
		gameObject.SetActive(false);
	}
	
	public void SetPosition(Vector3 position)
	{
		transform.position = new Vector3(position.x, transform.position.y, position.z + 3f);
	}
	
	private void LateUpdate()
	{
		transform.LookAt(transform.position + Camera.main.transform.forward);
	}
}
