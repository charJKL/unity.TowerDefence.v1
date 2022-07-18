using System.Collections;
using UnityEngine;

public class WaveMangerSpawner : MonoBehaviour
{
	[Header("References:")]
	[SerializeField] private Player player;
	[SerializeField] private Enemy enemy;
	
	[Header("Path information:")]
	[SerializeField] private Transform start;
	[SerializeField] private Waypoints waypoints;
	[SerializeField] private Transform end;
	
	[Header("Waves information:")]
	[SerializeField] private float timeBetweenWaves = 5f;
	[SerializeField] private int[] waves = {3, 1, 5, 1};
	
	const int PENALTY_FROM_PASSED_ENEMY = -1;
	private int waveIndex;
	
	private void Start()
	{
		waveIndex = 0;
		StartCoroutine(SpawnWave());
	}
	
	private IEnumerator SpawnWave()
	{
		while(true)
		{
			int enemies = waves[waveIndex];
			yield return StartCoroutine(SpawnEnemies(enemies));
			
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
			SpawnEnemy();
			
			currentEnemies++;
			if(currentEnemies >= enemiesToSpawn) yield break;
			yield return new WaitForSeconds(1f);
		}
	}
	
	private void SpawnEnemy()
	{
		GameObject instance = enemy.Init(start.position, waypoints);
		instance.GetComponent<EnemyFollowWaypoints>().OnArrivedToEnd += EnemyPassedEntirePath;
	}
	
	private void EnemyPassedEntirePath()
	{
		player.SetLives(PENALTY_FROM_PASSED_ENEMY);
	}
}
