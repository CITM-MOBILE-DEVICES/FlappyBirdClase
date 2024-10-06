using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
	private float spriteWidth;
	private int elementRepeat;

	private void Awake()
	{
		elementRepeat = transform.parent.childCount;
		spriteWidth = SpriteWidthBySpriteRenderer();
	}

	private void Update()
	{
		if (GameManager.Instance.CurrentGameState == GameManager.GameState.Play && (transform.position.x < -spriteWidth * elementRepeat))
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
}
