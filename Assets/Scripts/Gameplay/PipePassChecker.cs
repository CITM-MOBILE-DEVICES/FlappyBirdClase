using UnityEngine;

public class PipePassChecker : MonoBehaviour
{
	private void OnTriggerEnter2D()
	{
		GameManager.Instance.IncreaseScore();
	}
}
