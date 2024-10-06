using UnityEngine;
using static GameManager;

public class InitState : IGameState
{
	public GameManager.GameState CurrentState { get; set; }

	public InitState()
	{
		this.CurrentState = GameState.Init;
	}

	public void EnterState()
	{
		Time.timeScale = 0;
		Debug.Log("<b><color=yellow> Botón 2 para iniciar </color></b>");
	}
}
