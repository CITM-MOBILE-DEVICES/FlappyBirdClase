using System;

public class InputManager
{
	public void SubscribeInputs(Action togglePausePlay)
	{
		PlayerInputController.PressButtonB += togglePausePlay;
	}

	public void UnsubscribeInputs(Action togglePausePlay)
	{
		PlayerInputController.PressButtonB -= togglePausePlay;
	}
}
