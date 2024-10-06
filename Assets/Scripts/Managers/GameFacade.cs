using System;

public class GameFacade
{
	private GameStateManager gameStateManager;
	private ScoreManager scoreManager;
	private InputManager inputManager;

	public GameStateManager StateManager => gameStateManager;


	public GameFacade(PlayerInputController playerInputController)
	{
		gameStateManager = new GameStateManager();
		scoreManager = new ScoreManager();
		inputManager = new InputManager(playerInputController);
	}

	public void InitializeGame(Action togglePausePlay)
	{
		gameStateManager.ChangeState(new InitState());
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
			gameStateManager.ChangeState(new PauseState());
		}
		else if (gameStateManager.CurrentState == GameManager.GameState.Pause || gameStateManager.CurrentState == GameManager.GameState.Init)
		{
			gameStateManager.ChangeState(new PlayState());
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
		gameStateManager.ChangeState(new GameOverState());
	}
}
