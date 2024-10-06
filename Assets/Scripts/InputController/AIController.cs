using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class AIController
{
	private float nextFlapTime;

	public enum PlayerZone
	{
		Top,
		Center,
		Bottom
	}

	public PlayerZone playerZone;

	Tuple<float, float>[] pairIntervalFlap = new Tuple<float, float>[]
	{
		new Tuple<float, float>(0.95f, 1.4f),
		new Tuple<float, float>(0.65f, 0.9f),
		new Tuple<float, float>(0.3f, 0.7f)
	};

	float TopZone = 2;
	float BottomZone = -0.5f;

	private bool init = false;
	PlayerController playerController;

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

	public float NextFlapTime()
	{
		if (playerController.transform.position.y > TopZone)
		{
			playerZone = PlayerZone.Top;
		}
		else if (playerController.transform.position.y < BottomZone)
		{
			playerZone = PlayerZone.Bottom;
		}
		else
		{
			playerZone = PlayerZone.Center;
		}
		return Time.time + Random.Range(pairIntervalFlap[(int)playerZone].Item1, pairIntervalFlap[(int)playerZone].Item2);
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
}
