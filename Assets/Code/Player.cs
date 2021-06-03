using UnityEngine;

#pragma warning disable 414

namespace Code
{
    public class Player
    {
        public readonly float Movespeed;
        public readonly Sprite PlayerSprite;
        private readonly float _apexValue;

        public Player(string playername, Sprite playerSprite)
        {
            PlayerSprite = playerSprite;
            switch (playername)
            {
                case "HammerheadShark":
                    Movespeed = 150;
                    _apexValue = 5;
                    break;
                case "YellowFish":
                    Movespeed = 200;
                    _apexValue = 2;
                    break;
                case "killer Whale":
                    Movespeed = 100;
                    _apexValue = 6;
                    break;
            }

            PlayerMovement.MoveSpeed = Movespeed;
        }
    }
}