using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    private int TotalCoins;

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteKey("Coin");
        PlayerPrefs.DeleteKey("TotalCoins");
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
