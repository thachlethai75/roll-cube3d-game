using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    public Text coinText;
    public static int coinAmount;


    private void Awake()
    {
        coinAmount = PlayerPrefs.GetInt("CoinAmount", 0);
    }
    void Update()
    {
        coinText.text = "Gem: " + coinAmount.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
