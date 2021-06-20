using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class MainMenu : MonoBehaviour
    {
        private readonly int _totalCoins;

        public void PlayGame()
        {
            SceneManager.LoadScene("Game");
        }

        public void PlayMenu()
        {
            SceneManager.LoadScene("Menu");
        }
        public void QuitGame()
        {
            PlayerPrefs.DeleteKey("Coin");
            PlayerPrefs.DeleteKey("TotalCoins");
            Debug.Log("QUIT!");
            Application.Quit();
        }
    }
}