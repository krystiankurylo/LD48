using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using UnityEngine;

using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody2D))]
// [RequireComponent(typeof(Entity))]
// [RequireComponent(typeof(PlayerShooting))]
// [RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float walkingSpeed = 2f;

	[SerializeField]
	private float runningSpeed = 3f;

	public float moveSpeed = 5f;

	private Animator animator;

	// private Entity entity;

#pragma warning disable 108,114

	// ReSharper disable once IdentifierTypo
	public Rigidbody2D rigidbody;
#pragma warning restore 108,114

	private Vector2 movement;

	// private float xDirection;
	//
	// private float yDirection;

	// private GameManager gameManager;

	// public Vector2 Movement
	// {
	// 	get => movement;
	// }
	//
	// public Vector2 Direction
	// {
	// 	get { return new Vector2(xDirection, yDirection); }
	// }

	private float currentSpeed;

	// private static readonly int Horizontal = Animator.StringToHash("Horizontal");
	//
	// private static readonly int Vertical = Animator.StringToHash("Vertical");
	//
	// private static readonly int Speed = Animator.StringToHash("Speed");
	//
	// private static readonly int XDirection = Animator.StringToHash("xDirection");
	//
	// private static readonly int YDirection = Animator.StringToHash("yDirection");

	private void Start()
	{
		// rigidbody = GetComponent<Rigidbody2D>();
		// animator = GetComponent<Animator>();
		// entity = GetComponent<Entity>();

		// gameManager = FindObjectOfType<GameManager>();
	}

	private void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		// Debug.Log(movement.x);
		movement.y = Input.GetAxisRaw("Vertical");
		// Debug.Log(movement.y);

		// currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runningSpeed : walkingSpeed;

		// var movementNormalized = movement;
		//
		// animator.speed = currentSpeed / 3;
		// animator.SetFloat(Horizontal, movementNormalized.x);
		// animator.SetFloat(Vertical, movementNormalized.y);
		//
		// animator.SetFloat(Speed, movement.sqrMagnitude);

		if (Input.GetKeyUp(KeyCode.U))
		{
			var position = rigidbody.position;
			// rigidbody.MovePosition(new Vector2(position.x, position.y + 1.5f));
			rigidbody.position = new Vector2(position.x, position.y + 3.5f);
		}		
		
		if (Input.GetKeyUp(KeyCode.P))
		{
			var position = rigidbody.position;
			// rigidbody.MovePosition(new Vector2(position.x, position.y - 1.5f));
			rigidbody.position = new Vector2(position.x, position.y - 3.5f);
		}
	}

	private void FixedUpdate()
	{
		// rigidbody.MovePosition(rigidbody.position + movement * (currentSpeed * Time.fixedDeltaTime));
		rigidbody.MovePosition(rigidbody.position + movement * (moveSpeed * Time.fixedDeltaTime));

		// if (Math.Abs(movement.magnitude) > 0.5)
		// {
		// 	xDirection = animator.GetFloat(Horizontal);
		// 	yDirection = animator.GetFloat(Vertical);
		//
		// 	animator.SetFloat(XDirection, xDirection);
		// 	animator.SetFloat(YDirection, yDirection);
		// }
	}

	// private void OnCollisionEnter2D(Collision2D other)
	// {
	// 	if (other.gameObject.CompareTag("ScreamBullet"))
	// 	{
	// 		entity.GetHurt();
	// 	}
	// }

	// private void OnCollisionStay2D(Collision2D other)
	// {
	// 	if (other.gameObject.CompareTag("CoffeeShop"))
	// 		if (Input.GetKeyDown(KeyCode.E))
	// 			if (gameManager.GameWon)
	// 			{
	// 				WinGame();
	// 			}
	// }

	private void WinGame()
	{
		// canvas.GetComponent<EndMenu>().ShowEndMenu();
		// coffeeCanvas.SetActive(false);
	}

	private void Move()
	{
		var walkingDirection = Vector3.zero;
	
		walkingDirection += Vector3.up * Input.GetAxis("Vertical");
		walkingDirection += Vector3.right * Input.GetAxis("Horizontal");
	
		walkingDirection = walkingDirection.normalized;
		walkingDirection *= Input.GetKey(KeyCode.LeftShift) ? runningSpeed : walkingSpeed;
	
		rigidbody.MovePosition(transform.position + walkingDirection * Time.fixedDeltaTime);
	}
}
