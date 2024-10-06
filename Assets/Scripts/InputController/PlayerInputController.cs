using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
	public static event Action PressButtonA;
	public static event Action PressButtonB;
	public enum InputType
	{
		Keyboard,
		Mouse,
		AI
		//Online
	}

	[SerializeField] private InputType inputType;
	private IInputAdapter inputAdapter;

	private void Start()
	{
		switch (inputType)
		{
			case InputType.Keyboard:
				inputAdapter = new KeyboardInputAdapter();
				break;
			case InputType.Mouse:
				inputAdapter = new MouseInputAdapter();
				break;
			case InputType.AI:
				inputAdapter = new AIInputAdapter(FindObjectOfType<PlayerController>());
				break;
		}
	}

	void Update()
	{
		if (inputAdapter.IsPressingButtonA())
		{
			PressButtonA?.Invoke();
		}

		if (inputAdapter.IsPressingButtonB())
		{
			PressButtonB?.Invoke();
		}
	}
}
