using UnityEngine;
using static GameManager;

public class InitState : IGameState
{
	public GameManager.GameState currentState { get; set; }

	public InitState()
	{
		this.currentState = GameState.Init;
	}

	public void EnterState()
	{
		Time.timeScale = 0;
		Debug.Log("<b><color=yellow> Botón 2 para iniciar </color></b>");
	}
}
