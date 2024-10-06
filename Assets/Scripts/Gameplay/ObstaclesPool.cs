using UnityEngine;
using static GameManager;

public class ObstaclesPool : MonoBehaviour
{
	[SerializeField] private float spawnTime = 2.5f;
	private float timeElapsed;

	[SerializeField] private GameObject obstaclePrefab;
	[SerializeField] private int poolSize = 5;
	private GameObject[] obstacles;
	private int obstacleCount;

	[SerializeField] private float xSpawnPosition = 12f;
	[SerializeField] private float minYPosition = -2f;
	[SerializeField] private float maxYPosition = 3f;

	private void Start()
	{
		PrepareObstacles();
	}

	private void Update()
	{
		timeElapsed += Time.deltaTime;
		if (timeElapsed > spawnTime && GameManager.Instance.currentGameState == GameState.Play)
		{
			SpawnObstacle();
		}
	}

	private void PrepareObstacles()
	{
		GameObject parent = GameObject.Find("Obstacles");
		obstacles = new GameObject[poolSize];
		for (int i = 0; i < poolSize; i++)
		{
			obstacles[i] = Instantiate(obstaclePrefab, parent.transform);
			obstacles[i].SetActive(false);
		}
	}

	private void SpawnObstacle()
	{
		timeElapsed = 0f;

		SetObstacle();

		obstacleCount++;

		if (obstacleCount == poolSize)
		{
			obstacleCount = 0;
		}
	}

	private void SetObstacle()
	{
		float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
		Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
		obstacles[obstacleCount].transform.position = spawnPosition;

		if (!obstacles[obstacleCount].activeSelf)
		{
			obstacles[obstacleCount].SetActive(true);
		}
	}
}
