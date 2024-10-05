using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameState
{
    GameManager.GameState currentState { get; set; }

    void EnterState();
}
