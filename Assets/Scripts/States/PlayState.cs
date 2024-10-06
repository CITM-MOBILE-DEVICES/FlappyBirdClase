using UnityEngine;
using static GameManager;

public class PlayState : IGameState
{
	public GameManager.GameState currentState { get; set; }
	public PlayState()
	{
		this.currentState = GameState.Play;
	}

	public void EnterState()
	{
		Time.timeScale = 1;
		AudioManager.Instance.PlayMusic("Theme");
	}
}
