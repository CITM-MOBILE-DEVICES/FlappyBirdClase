using UnityEngine;
using static GameManager;

public class Scroll : MonoBehaviour
{
	[SerializeField] private GameFacade gameFacade;
	[SerializeField] private float speed = 2.5f;
	private Rigidbody2D rigidBody;
	private void Awake()
	{
		gameFacade = FindObjectOfType<GameFacade>();
	}
	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		SetScroll(GameManager.Instance.CurrentGameState);
		gameFacade.StateManager.OnChangeState += SetScroll;
	}

	private void OnDestroy()
	{
		gameFacade.StateManager.OnChangeState -= SetScroll;
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
