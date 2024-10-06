using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
	private float spriteWidth;
	private int elementRepeat;

	private void Awake()
	{
		elementRepeat = transform.parent.childCount;
	}
	private void Start()
	{
		spriteWidth = SpriteWidthBySpriteRenderer();
	}
	private void Update()
	{


		if (GameManager.Instance.currentGameState == GameManager.GameState.Play && (transform.position.x < -spriteWidth * elementRepeat))
		{
			ResetPosition();
		}
	}

	private void ResetPosition()
	{
		transform.Translate(new Vector3(2 * elementRepeat * spriteWidth, 0f, 0f));
	}

	private float SpriteWidthBySpriteRenderer()
	{
		Sprite sprite = GetComponent<SpriteRenderer>().sprite;
		return sprite.texture.width / sprite.pixelsPerUnit;
	}

	private float SpriteWidthByBoxCollider()
	{
		BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
		return groundCollider.size.x;
	}
}
