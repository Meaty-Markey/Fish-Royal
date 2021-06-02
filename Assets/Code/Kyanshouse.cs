using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Kyanshouse : MonoBehaviour
{
    public TMP_Text Coin;
    public Sprite KillerWhale;
    public Sprite HammerheadShark; 
    public Sprite YellowFish; 
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
        MainPlayer = new Player("YellowFish", YellowFish);
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("Coin"));
        Coin.text = ($"Coins: {PlayerPrefs.GetInt("TotalCoins")}");
    }

    public void KillerWhaleButton()
    {
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - 100);
        Coin.text = $"Coins: {PlayerPrefs.GetInt("TotalCoins")}";
        MainPlayer = new Player("killer Whale", KillerWhale);
        Debug.Log($"PAID");
    }

    public void HammerHeadButton()
    {
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - 50);
        Coin.text = $"Coins: {PlayerPrefs.GetInt("TotalCoins")}";
        MainPlayer = new Player("HammerheadShark", HammerheadShark);
        Debug.Log($"PAID");
    }



}
