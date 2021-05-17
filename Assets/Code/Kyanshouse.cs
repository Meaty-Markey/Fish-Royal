using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Kyanshouse : MonoBehaviour
{
    public TMP_Text Coin;
    private int TotalCoins;

    Dictionary<string,bool> unlockList = new Dictionary<string,bool>();
    private void DeleteDate()
    {
        PlayerPrefs.DeleteKey("TotalCoins");
        PlayerPrefs.DeleteKey("Coin");
    }
    void Start()
    {
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("Coin"));
        Coin.text = ($"Coins: {PlayerPrefs.GetInt("TotalCoins")}");
    }

   public void REALLLYCOOLBUTTON()
    {
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - 1);
        Coin.text = $"Coins: {PlayerPrefs.GetInt("TotalCoins")}";
        SceneManager.LoadScene("Game(KillerWhale)");

    }

   
}
