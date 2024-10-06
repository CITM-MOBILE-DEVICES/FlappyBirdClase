using UnityEngine;
using static GameManager;

public class Scroll : MonoBehaviour
{
	[SerializeField] private float speed = 2.5f;
	private Rigidbody2D rigidBody;
	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		SetScroll(GameManager.Instance.CurrentGameState);
		GameManager.Instance.OnChangeState += SetScroll;
	}

	private void OnDestroy()
	{
		GameManager.Instance.OnChangeState -= SetScroll;
	}

	private void SetScroll(GameState gameState)
	{
		if (gameState == GameState.Play)
		{
			StartScroll();
		}
		else
		{
			StopScroll();
		}
	}

	private void StartScroll()
	{
		rigidBody.velocity = Vector2.left * speed;
	}

	private void StopScroll()
	{
		rigidBody.velocity = Vector2.zero;
	}
}
