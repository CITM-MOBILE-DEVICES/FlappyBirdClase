using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	public static GameManager Instance { get { return instance; } }

	private GameFacade gameFacade;

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
			gameFacade = new GameFacade();
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public event Action<GameState> OnChangeState
	{
		add { gameFacade.OnChangeState += value; }
		remove { gameFacade.OnChangeState -= value; }
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

	public GameState currentGameState { get { return gameFacade.GetCurrentGameState(); } }
}