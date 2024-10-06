using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class AIController
{
	public enum PlayerZone
	{
		Top,
		Center,
		Bottom
	}

	public PlayerZone playerZone;

	private Tuple<float, float>[] pairIntervalFlap = new Tuple<float, float>[]
	{
		new Tuple<float, float>(0.95f, 1.4f),
		new Tuple<float, float>(0.65f, 0.9f),
		new Tuple<float, float>(0.3f, 0.7f)
	};

	private float nextFlapTime;
	private float topZone = 2;
	private float bottomZone = -0.5f;

	private bool init = false;
	private PlayerController playerController;

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
		return Time.time + Random.Range(pairIntervalFlap[(int)playerZone].Item1, pairIntervalFlap[(int)playerZone].Item2);
	}
}
