using UnityEngine;

namespace Code
{
    public class Player
    {
        public Sprite _PlayerSprite;
        public float movespeed, apex_value;
        public string name;

        public Player(string Playername, Sprite PlayerSprite)
        {
            name = Playername;
            _PlayerSprite = PlayerSprite;
            switch (Playername)
            {
                case "HammerheadShark":
                    movespeed = 150;
                    apex_value = 5;
                    break;
                case "YellowFish":
                    Debug.Log("Hot");
                    movespeed = 200;
                    apex_value = 2;
                    break;
                case "killer Whale":
                    movespeed = 100;
                    apex_value = 6;
                    break;
            }

            PlayerMovement.moveSpeed = movespeed;
        }
    }
}