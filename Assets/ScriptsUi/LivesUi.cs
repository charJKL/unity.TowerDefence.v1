using UnityEngine;
using UnityEngine.UI;

public class LivesUi : MonoBehaviour
{
	[SerializeField] private Image slider;
	
	private float width;
	
	private void Awake()
	{
		width = slider.sprite.rect.width;
	}
	
	public void SetLives(int lives)
	{
		slider.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width * lives);
	}
}
