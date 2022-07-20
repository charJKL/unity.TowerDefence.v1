using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private WaveMangerSpawner waveMangerSpawner;
	[SerializeField] private uiGameMenu uiGameMenu;
	
	private bool isGameOver;
	private bool isGamePaused;
	private bool isGameOverUiVisible;
	private int waveCompleted;
	
	private void Start()
	{
		player.OnLivesChanged += CheckIfPlayerLoose;
		waveMangerSpawner.OnWaveCompleted += (int wave) => waveCompleted = wave;
		uiGameMenu.uiResumeButton.onClick.AddListener(ResumeGame);
		uiGameMenu.uiRestartButton.onClick.AddListener(Restart);
	}
	
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape) && isGameOver)
		{
			BackToMain();
			return;
		}
		if(Input.GetKeyDown(KeyCode.Escape) && !isGamePaused)
		{
			PauseGame();
			return;
		}
		if(Input.GetKeyDown(KeyCode.Escape) && isGamePaused)
		{
			ResumeGame();
			return;
		}
	}
	
	private void CheckIfPlayerLoose(int lives)
	{
		isGameOver = lives > 0 ? false : true;
		if(isGameOver) GameOver();
	}
	
	public void GameOver()
	{
		if(isGameOverUiVisible) return;
		uiGameMenu.SetWaveText(waveCompleted);
		uiGameMenu.ShowGameOver();
		isGameOverUiVisible = true;
	}
	
	public void PauseGame()
	{
		Time.timeScale = 0;
		isGamePaused = true;
		uiGameMenu.ShowPause();
	}
	
	public void ResumeGame()
	{
		Time.timeScale = 1;
		isGamePaused = false;
		uiGameMenu.HidePause();
	}
	
	public void BackToMain()
	{
		SceneManager.LoadScene("Main");
	}
	
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
