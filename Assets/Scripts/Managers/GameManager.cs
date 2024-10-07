using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager Instance { get { return instance; } }
	private static GameManager instance;

	public GameState CurrentGameState { get { return gameFacade.GetCurrentGameState(); } }

	[SerializeField]private GameFacade gameFacade;

	public enum GameState
	{
		Init,
		Play,
		Pause,
		GameOver
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		gameFacade.InitializeGame(TogglePausePlay);
	}

	private void OnDestroy()
	{
		gameFacade.CleanUpGame(TogglePausePlay);
	}

	private void TogglePausePlay()
	{
		gameFacade.TogglePausePlay();
	}

	public void IncreaseScore()
	{
		gameFacade.IncreaseScore();
	}

	public void GameOver()
	{
		gameFacade.GameOver();
	}
}