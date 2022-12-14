using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerController : MonoBehaviour
{
	public GameObject player;
	public GameObject Sprite { get { return player.transform.Find("Sprite").gameObject; } }
	public Animator Animator { get { return player.GetComponent<Animator>(); } }

	[SerializeField] private float vel;

	private Vector2 direction = Vector2.zero;
	public Vector2 Direction { get { return direction; } }
	private Vector2 movement = Vector2.zero;
	public Vector2 Movement { get { return movement; } }

	public Characters character;

	void Update()
	{
		HandleKeyboard();

		Vector2 newPosition = player.transform.position;
		newPosition.x += movement.x * vel;
		newPosition.y += movement.y * vel;

		AnimateWalk();
		Move(newPosition);
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

	public bool IsMoving() => !movement.Equals(Vector2.zero);

	protected internal void Move(Vector2 newPosition) => player.transform.position = newPosition;

	protected void AnimateWalk()
	{
		Animator.speed = Math.Max(vel, 0.1f);
		switch (direction)
		{
			case Vector2 v when v.Equals(Vector2.right):
				Animator.Play(IsMoving() ? "Walk Right" : "Stand");
				break;
			case Vector2 v when v.Equals(Vector2.up):
				Animator.Play(IsMoving() ? "Walk Back" : "Stand");
				break;
			case Vector2 v when v.Equals(Vector2.down):
				Animator.Play(IsMoving() ? "Walk Front" : "Stand");
				break;
			case Vector2 v when v.Equals(Vector2.left):
				Animator.Play(IsMoving() ? "Walk Left" : "Stand");
				break;
		}
	}
}

public enum Characters
{
	Wizard,
	Priest
}