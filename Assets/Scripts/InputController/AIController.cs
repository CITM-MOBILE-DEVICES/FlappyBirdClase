using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class AIController
{
	private enum PlayerZone
	{
		Top,
		Center,
		Bottom
	}

	private readonly Tuple<float, float>[] pairIntervalFlap = new Tuple<float, float>[]
	{
		new Tuple<float, float>(0.95f, 1.4f),
		new Tuple<float, float>(0.65f, 0.9f),
		new Tuple<float, float>(0.3f, 0.7f)
	};

	private readonly PlayerController playerController;
	private readonly float topZone = 2;
	private readonly float bottomZone = -0.5f;

	private float nextFlapTime;
	private bool init = false;

	public AIController(PlayerController playerController)
	{
		this.playerController = playerController;
		nextFlapTime = NextFlapTime();

	}

	public bool ShouldPressButtonA()
	{
		if (Time.time >= nextFlapTime)
		{
			nextFlapTime = NextFlapTime();
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool ShouldPressButtonB()
	{
		if (init == false)
		{
			init = !init;
			return true;
		}
		return false;
	}

	private float NextFlapTime()
	{
		PlayerZone playerZone;

		if (playerController.transform.position.y > topZone)
		{
			playerZone = PlayerZone.Top;
		}
		else if (playerController.transform.position.y < bottomZone)
		{
			playerZone = PlayerZone.Bottom;
		}
		else
		{
			playerZone = PlayerZone.Center;
		}
		
		var pairIntervalFlapElement = pairIntervalFlap[(int)playerZone];

		return Time.time + Random.Range(pairIntervalFlapElement.Item1, pairIntervalFlapElement.Item2);
	}
}
