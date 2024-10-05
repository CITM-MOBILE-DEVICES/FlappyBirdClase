using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade
{
    private GameStateManager gameStateManager;
    private ScoreManager scoreManager;
    private InputManager inputManager;

    public event Action<GameManager.GameState> OnChangeState
    {
        add { gameStateManager.OnChangeState += value; }
        remove { gameStateManager.OnChangeState -= value; }
    }


    public GameFacade()
    {
        gameStateManager = new GameStateManager();
        scoreManager = new ScoreManager();
        inputManager = new InputManager();
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
