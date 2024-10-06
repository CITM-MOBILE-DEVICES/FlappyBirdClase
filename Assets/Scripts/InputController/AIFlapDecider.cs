using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIFlapDecider
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

	public AIFlapDecider(PlayerController playerController)
	{
		this.playerController = playerController;
		nextFlapTime = NextFlapTime();

	}

	public bool ShouldFlap()
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
