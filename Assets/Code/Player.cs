using UnityEngine;

public class Player
{
	public float movespeed, apex_value;
	public string name;
	public Sprite _PlayerSprite;
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
			case "Fish":
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
