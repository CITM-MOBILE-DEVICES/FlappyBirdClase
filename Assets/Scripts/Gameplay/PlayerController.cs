using UnityEngine;
using static GameManager;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float upForce = 225f;
	private Rigidbody2D playerRb;

	private void Awake()
	{
		playerRb = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		PlayerInputController.PressButtonA += Flap;
	}

	private void OnDestroy()
	{
		PlayerInputController.PressButtonA -= Flap;
	}

	private void Flap()
	{
		if (GameManager.Instance.CurrentGameState == GameState.Play)
		{
			playerRb.velocity = Vector2.zero;
			playerRb.AddForce(Vector2.up * upForce);
			AudioManager.Instance.PlaySFX("Wing");
		}
	}

	private void OnCollisionEnter2D()
	{
		if (GameManager.Instance.CurrentGameState == GameManager.GameState.Play)
		{
			AudioManager.Instance.PlaySFX("Gameover");
			GameManager.Instance.GameOver();
		}
	}
}
