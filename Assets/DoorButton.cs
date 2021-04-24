using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DoorButton : MonoBehaviour
{
	[SerializeField]
	private GameObject door;

	[SerializeField]
	private GameObject uiText;

	[SerializeField]
	private GameObject uiPanel;

	private bool clickable;

	private bool doorDestroyed;

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag("Player") && !doorDestroyed)
		{
			Debug.Log("player");
			clickable = true;

			uiPanel.SetActive(true);
			uiText.SetActive(true);
		}
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.collider.CompareTag("Player"))
		{
			clickable = false;

			uiPanel.SetActive(false);
			uiText.SetActive(false);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && clickable && !doorDestroyed)
		{
			// Destroy(door);
			door.SetActive(false);
			doorDestroyed = true;
			uiPanel.SetActive(false);
			uiText.SetActive(false);
		}
	}
}
