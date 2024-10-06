public class AIInputAdapter : IInputAdapter
{
	private readonly AIFlapDecider aiFlapDecider;
	private bool init = false;

	public AIInputAdapter(PlayerController playerController)
	{
		aiFlapDecider = new AIFlapDecider(playerController);
	}

	public bool IsPressingButtonA()
	{
		return aiFlapDecider.ShouldFlap();
	}

	public bool IsPressingButtonB()
	{
		if (init == false)
		{
			init = !init;
			return true;
		}
		return false;
	}
}
