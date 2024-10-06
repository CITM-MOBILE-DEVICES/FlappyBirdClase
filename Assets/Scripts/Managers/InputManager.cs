using System;

public class InputManager
{
	private readonly PlayerInputController playerInputController;

	public InputManager(PlayerInputController playerInputController)
	{
		this.playerInputController = playerInputController;
	}

	public void SubscribeInputs(Action togglePausePlay)
	{
		playerInputController.PressButtonB += togglePausePlay;
	}

	public void UnsubscribeInputs(Action togglePausePlay)
	{
		playerInputController.PressButtonB -= togglePausePlay;
	}
}
