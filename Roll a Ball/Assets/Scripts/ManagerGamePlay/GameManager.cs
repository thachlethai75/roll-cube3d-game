using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject completeLevelUI;
    [SerializeField] private PlayerMovement movement;
    public GameData gameData;
    bool gameEnded = false;
    private float restartRelay = 1f;

    private void Awake()
    {
        gameData = SaveSystem.Load();
    }
    public void EndGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("End Game");
            Invoke("Restart", restartRelay);
        }
    }

    public void CompletLevel()
    {
        Debug.Log("Game Won");
        gameData.totalGem += PlayerCollision.coinAmount;
        SaveSystem.Save(gameData);
        completeLevelUI.SetActive(true);
        movement.enabled = false;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Pause()
    {
        // Pause Menu
        

    }
}
