using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private PlayerInputController playerInputController;

	public static GameManager Instance { get { return instance; } }
	private static GameManager instance;

	public GameState CurrentGameState { get { return gameFacade.GetCurrentGameState(); } }

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
			gameFacade = new GameFacade(playerInputController);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public GameStateManager StateManager => gameFacade.StateManager;

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