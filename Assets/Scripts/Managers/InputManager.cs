using System;

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
