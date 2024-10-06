using UnityEngine;

public class MouseInputAdapter : IInputAdapter
{
	public bool IsPressingButtonA()
	{
		return Input.GetMouseButtonDown(0);
	}

	public bool IsPressingButtonB()
	{
		return Input.GetMouseButtonDown(1);
	}
}
