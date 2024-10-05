using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class GameOverState : IGameState
{
    private const float TIMERETRY = 1.5f;

    public GameManager.GameState currentState { get; set; }

    public GameOverState()
    {
        this.currentState = GameState.GameOver;
    }

    public void EnterState()
    {
        Time.timeScale = 1;
        GameManager.Instance.StartCoroutine(InfoGameOverAndRestart());
    }

    private IEnumerator InfoGameOverAndRestart()
    {
        Debug.Log("<b><color=red> GAMEOVER </color></b>");
        yield return new WaitForSeconds(TIMERETRY);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
