public interface IGameState
{
	GameManager.GameState currentState { get; set; }

	void EnterState();
}
