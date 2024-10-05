using UnityEngine;
using static GameManager;

public class PauseState : IGameState
{
    public GameManager.GameState currentState { get; set; }
    public PauseState()
    {
        this.currentState = GameState.Pause;
    }

    public void EnterState()
    {
        Time.timeScale = 0;
        Debug.Log("<b><color=green> PAUSA: Botón 2 para despausar </color></b>");
        AudioManager.Instance.musicSource.Pause();
    }
}
