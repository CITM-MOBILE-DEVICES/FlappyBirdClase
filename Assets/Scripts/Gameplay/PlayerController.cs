using System.Collections;
using System.Collections.Generic;
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
        PlayerInputController.pressButtonA += Flap;
    }

    private void OnDestroy()
    {
        PlayerInputController.pressButtonA -= Flap;
    }

    private void Flap()
    {
        if(GameManager.Instance.currentGameState == GameState.Play)
        {
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(Vector2.up * upForce);
            AudioManager.Instance.PlaySFX("Wing");
        }  
    }

    private void OnCollisionEnter2D()
    { 
        if(GameManager.Instance.currentGameState == GameManager.GameState.Play)
        {
            AudioManager.Instance.PlaySFX("Gameover");
            GameManager.Instance.GameOver();
        }
    }
}
