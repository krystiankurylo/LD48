using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField]
    private GameObject door;

    private bool clickable;

    private bool doorDestroyed;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("player");
            clickable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        clickable = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && clickable && !doorDestroyed)
        {
            // Destroy(door);
            door.SetActive(false);
            doorDestroyed = true;
        }
    }
}
