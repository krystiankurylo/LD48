using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CratesMovement : MonoBehaviour
{
	//Assign a GameObject in the Inspector to rotate around
	private GameObject target;

	private bool rotatable;

	private void Awake()
	{
		target = GameObject.FindGameObjectWithTag("Player");
		rotatable = true;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A) && rotatable)
		{
			rotatable = false;
			RotateLeft();
		}

		if (Input.GetKeyDown(KeyCode.D) && rotatable)
		{
			rotatable = false;
			RotateRight();
		}
	}

	private void RotateLeft()
	{
		transform.RotateAround(
			target.transform.position,
			Vector3.forward,
			45);
		rotatable = true;
	}

	private void RotateRight()
	{
		transform.RotateAround(
			target.transform.position,
			Vector3.forward,
			-45);
		rotatable = true;
	}

}
