using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    private int score = 0;

    public ScoreManager()
    {
        
    }

    public void IncreaseScore()
    {
        score++;
        Debug.Log("<b><color=white>" + score + "</color></b>");
        AudioManager.Instance.PlaySFX("Point");
    }
}
