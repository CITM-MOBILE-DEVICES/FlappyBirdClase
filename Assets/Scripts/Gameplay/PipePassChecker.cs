using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePassChecker : MonoBehaviour
{
    private int score;
    private void OnTriggerEnter2D()
    {
        GameManager.Instance.IncreaseScore();
    }
}
