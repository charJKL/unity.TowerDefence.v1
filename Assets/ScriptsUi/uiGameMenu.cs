using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class uiGameMenu : MonoBehaviour
{
	[SerializeField] private GameObject uiGameOver;
	[SerializeField] private GameObject uiPause;
	[SerializeField] private GameObject uiWavesGroup;
	[SerializeField] private TextMeshProUGUI uiWavesText;
	[SerializeField] private Button uiResume;
	[SerializeField] private Button uiRestart;
	
	public Button uiResumeButton { get => uiResume; } 
	public Button uiRestartButton { get => uiRestart; } 

	public void ShowGameOver()
	{
		gameObject.SetActive(true);
		uiGameOver.SetActive(true);
		uiPause.SetActive(false);
		uiWavesGroup.SetActive(true);
		uiResume.interactable = false;
		uiRestart.interactable = true;
	}
	
	public void ShowPause()
	{
		gameObject.SetActive(true);
		uiGameOver.SetActive(false);
		uiPause.SetActive(true);
		uiWavesGroup.SetActive(false);
		uiResume.interactable = true;
		uiRestart.interactable = false;
	}	
	
	public void HidePause()
	{
		gameObject.SetActive(false);
		uiGameOver.SetActive(false);
		uiPause.SetActive(false);
		uiWavesGroup.SetActive(false);
		uiResume.interactable = false;
		uiRestart.interactable = false;
	}
	
	public void SetWaveText(int wave)
	{
		uiWavesText.SetText(wave.ToString());
	}
}
