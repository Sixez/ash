using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerController : MonoBehaviour
{
	public GameObject player;
	public GameObject sprite { get { return player.transform.Find("Sprite").gameObject; } }
	private Animator animator { get { return player.GetComponent<Animator>(); } }

	[SerializeField] private float vel = 0.01f;

	private Vector2 direction = Vector2.zero;
	private Vector2 movement = Vector2.zero;

	public Character character;

	void Update()
	{
		HandleKeyboard();

		if (IsMoving())
		{
			Vector2 newPosition = player.transform.position;
			newPosition.x += movement.x * vel;
			newPosition.y += movement.y * vel;

			AnimateWalk();
			Move(newPosition);
		}
	}

	private void HandleKeyboard()
	{
		if (Input.GetKeyDown(KeyCode.A)) movement.x += -1;
		if (Input.GetKey(KeyCode.A)) direction.Set(-1, 0);
		if (Input.GetKeyUp(KeyCode.A)) movement.x -= -1;

		if (Input.GetKeyDown(KeyCode.S)) movement.y += -1;
		if (Input.GetKey(KeyCode.S)) direction.Set(0, -1);
		if (Input.GetKeyUp(KeyCode.S)) movement.y -= -1;

		if (Input.GetKeyDown(KeyCode.W)) movement.y += 1;
		if (Input.GetKey(KeyCode.W)) direction.Set(0, 1);
		if (Input.GetKeyUp(KeyCode.W)) movement.y -= 1;

		if (Input.GetKeyDown(KeyCode.D)) movement.x += 1;
		if (Input.GetKey(KeyCode.D)) direction.Set(1, 0);
		if (Input.GetKeyUp(KeyCode.D)) movement.x -= 1;
			
	}

	private bool IsMoving()
	{
		return !movement.Equals(Vector2.zero);
	}

	private void Move(Vector2 newPosition)
	{
		player.transform.position = newPosition;
	}

	private void AnimateWalk()
	{
		animator.speed = 1f / 10f;

		switch(direction)
		{
			case Vector2 v when v.Equals(Vector2.right):
				animator.Play("Walk Right");
				break;
			case Vector2 v when v.Equals(Vector2.up):
				animator.Play("Walk Back");
				break;
			case Vector2 v when v.Equals(Vector2.down):
				animator.Play("Walk Front");
				break;
			case Vector2 v when v.Equals(Vector2.left):
				animator.Play("Walk Left");
				break;
		}
	}
}

public enum Character
{
	Wizard,
	Priest
}