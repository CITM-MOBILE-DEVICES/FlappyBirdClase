using System;
using static GameManager;

public class GameStateManager
{
    public GameManager.GameState CurrentState { get; private set; }

    public event Action<GameManager.GameState> OnChangeState;

    public void SetState(IGameState newState)
    {
        CurrentState = newState.currentState;
        newState.EnterState();
        OnChangeState?.Invoke(CurrentState);
    }
}
