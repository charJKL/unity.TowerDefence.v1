using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMangerSpawner : MonoBehaviour
{
	[Header("Map information:")]
	[SerializeField] private Transform start;
	[SerializeField] private Waypoints waypoints;
	[SerializeField] private Enemy enemy;
	[Header("Waves information:")]
	[SerializeField] private float timeBetweenWaves = 5f;
	[SerializeField] private int[] waves = {3, 1, 5, 1};
	
	private bool allEnemiesSpawned;
	private int waveIndex;
	
	private void Start()
	{
		allEnemiesSpawned = false;
		waveIndex = 0;
		StartCoroutine(SpawnWave());
	}
	
	private IEnumerator SpawnWave()
	{
		while(true)
		{
			int enemies = waves[waveIndex];
			allEnemiesSpawned = false;
			StartCoroutine(SpawnEnemies(enemies));
			yield return new WaitUntil(() => allEnemiesSpawned);
			
			waveIndex++;
			if(waveIndex >= waves.Length) yield break;
			
			yield return new WaitForSeconds(timeBetweenWaves);
		}
	}

	private IEnumerator SpawnEnemies(int enemiesToSpawn)
	{
		int currentEnemies = 0;
		while(true)
		{
			enemy.Init(start.position, waypoints);
			
			currentEnemies++;
			if(currentEnemies >= enemiesToSpawn)
			{
				allEnemiesSpawned = true;
				yield break;
			}
			
			yield return new WaitForSeconds(1f);
		}
	}
}
