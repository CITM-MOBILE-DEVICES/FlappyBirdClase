using UnityEngine;
using static GameManager;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private PlayerInputController playerInputController;
	[SerializeField] private float upForce = 225f;
	[SerializeField] private Rigidbody2D playerRb;

	private void Start()
	{
		playerInputController.PressButtonA += Flap;
	}

	private void OnDestroy()
	{
		playerInputController.PressButtonA -= Flap;
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
