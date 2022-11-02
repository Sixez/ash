using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.U2D.Animation;

public class MovementAnimationController : MonoBehaviour
{
	public GameObject player;
	private PlayerController playerController { get { return player.GetComponent<PlayerController>(); } }
	private SpriteRenderer spriteRenderer { get { return playerController.sprite.GetComponent<SpriteRenderer>(); } }
	private SpriteResolver spriteResolver { get { return playerController.sprite.GetComponent<SpriteResolver>(); } }

	private void UpdateSprite(string spriteName)
	{
		spriteResolver.SetCategoryAndLabel(playerController.character.ToString(), spriteName);
		spriteResolver.ResolveSpriteToSpriteRenderer();
	}

	public void OnMove(int id)
	{
		switch (id)
		{
			case 0:
				spriteRenderer.flipX = false;
				UpdateSprite("std_0");
				break;
			case 1: UpdateSprite("std_1"); break;
			case 10: UpdateSprite("front_1"); break;
			case 11: UpdateSprite("front_2"); break;
			case 20: UpdateSprite("back_1"); break;
			case 21: UpdateSprite("back_2"); break;
			case 30:
				spriteRenderer.flipX = true;
				UpdateSprite("std_0");
				break;
			case 31: UpdateSprite("std_1"); break;
		}
	}
}
