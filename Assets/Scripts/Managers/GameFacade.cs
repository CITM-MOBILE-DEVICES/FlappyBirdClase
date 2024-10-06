using System;

public class GameFacade
{
	private GameStateManager gameStateManager;
	private ScoreManager scoreManager;
	private InputManager inputManager;
	private PlayerInputController playerInputController;

	public event Action<GameManager.GameState> OnChangeState
	{
		add { gameStateManager.OnChangeState += value; }
		remove { gameStateManager.OnChangeState -= value; }
	}


	public GameFacade(PlayerInputController playerInputController)
	{
		gameStateManager = new GameStateManager();
		scoreManager = new ScoreManager();
		inputManager = new InputManager(playerInputController);
	}

	public void InitializeGame(Action togglePausePlay)
	{
		gameStateManager.SetState(new InitState());
		inputManager.SubscribeInputs(togglePausePlay);
	}

	public void CleanUpGame(Action togglePausePlay)
	{
		inputManager.UnsubscribeInputs(togglePausePlay);
	}

	public void TogglePausePlay()
	{
		if (gameStateManager.CurrentState == GameManager.GameState.Play)
		{
			gameStateManager.SetState(new PauseState());
		}
		else if (gameStateManager.CurrentState == GameManager.GameState.Pause || gameStateManager.CurrentState == GameManager.GameState.Init)
		{
			gameStateManager.SetState(new PlayState());
		}
	}

	public void IncreaseScore()
	{
		scoreManager.IncreaseScore();
	}

	public GameManager.GameState GetCurrentGameState()
	{
		return gameStateManager.CurrentState;
	}

	public void GameOver()
	{
		gameStateManager.SetState(new GameOverState());
	}
}
