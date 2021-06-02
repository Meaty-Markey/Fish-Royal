using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Code
{
    public class Kyanshouse : MonoBehaviour
    {
        public static Player MainPlayer;
        public TMP_Text Coin;
        public Sprite KillerWhale;
        public Sprite HammerheadShark;
        public Sprite YellowFish;
        private int TotalCoins;

        private Dictionary<string, bool> unlockList = new Dictionary<string, bool>();

        private void Start()
        {
            MainPlayer = new Player("YellowFish", YellowFish);
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("Coin"));
            Coin.text = $"Coins: {PlayerPrefs.GetInt("TotalCoins")}";
        }

        private void DeleteDate()
        {
            PlayerPrefs.DeleteKey("TotalCoins");
            PlayerPrefs.DeleteKey("Coin");
        }

        public void KillerWhaleButton()
        {
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - 100);
            Coin.text = $"Coins: {PlayerPrefs.GetInt("TotalCoins")}";
            MainPlayer = new Player("killer Whale", KillerWhale);
            Debug.Log("PAID");
        }

        public void HammerHeadButton()
        {
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - 50);
            Coin.text = $"Coins: {PlayerPrefs.GetInt("TotalCoins")}";
            MainPlayer = new Player("HammerheadShark", HammerheadShark);
            Debug.Log("PAID");
        }
    }
}