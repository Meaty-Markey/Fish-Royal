using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Kyanshouse : MonoBehaviour
{
    public TMP_Text Coin;
    public Sprite KillerWhale;
    public Sprite HammerheadShark; 
    private int TotalCoins;
    public static Player MainPlayer;

    Dictionary<string,bool> unlockList = new Dictionary<string,bool>();
    private void DeleteDate()
    {
        PlayerPrefs.DeleteKey("TotalCoins");
        PlayerPrefs.DeleteKey("Coin");
    }
    void Start()
    {
        MainPlayer = new Player("Fish", HammerheadShark);
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("Coin"));
        Coin.text = ($"Coins: {PlayerPrefs.GetInt("TotalCoins")}");
    }

    public void HammerHeadshark()
    {
        MainPlayer = new Player("HammerheadShark", HammerheadShark);
        Debug.Log($"PAID");
    }

    public void Killerwhale()
    {
        MainPlayer = new Player("killer Whale", KillerWhale);
        Debug.Log($"PAID");
    }
    public void REALLLYCOOLBUTTON()
    {
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - 1);
        Coin.text = $"Coins: {PlayerPrefs.GetInt("TotalCoins")}";
        SceneManager.LoadScene("Game(KillerWhale)");

    }



}
