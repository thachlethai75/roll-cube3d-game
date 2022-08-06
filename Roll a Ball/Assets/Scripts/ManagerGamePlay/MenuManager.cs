using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Text coinText;
    bool isPlayed = true;

    int coinAmount;

    private void Start()
    {
        audioSource.GetComponent<AudioSource>();
        audioSource.Play();
        coinAmount = PlayerCollision.coinAmount;
        coinAmount = PlayerPrefs.GetInt("CoinAmount", 0);
    }
    private void Update()
    {
        coinText.text = "Gem: " + coinAmount.ToString();

    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void LevelSelector()
    {
        SceneManager.LoadScene("ChossenLevel");
    }

    public void ShopOpen()
    {
        SceneManager.LoadScene("ShopScene");
    }


    
}
