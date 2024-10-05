using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public void SubscribeInputs(Action togglePausePlay)
    {
        PlayerInputController.pressButtonB += togglePausePlay;
    }

    public void UnsubscribeInputs(Action togglePausePlay)
    {
        PlayerInputController.pressButtonB -= togglePausePlay;
    }
}
