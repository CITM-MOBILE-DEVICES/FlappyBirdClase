using System;

public class GameStateManager
{
	public GameManager.GameState CurrentState { get; private set; }

	public event Action<GameManager.GameState> OnChangeState;

	public void ChangeState(IGameState newState)
	{
		CurrentState = newState.CurrentState;
		newState.EnterState();
		OnChangeState?.Invoke(CurrentState);
	}
}
