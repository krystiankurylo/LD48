using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameWon { get; set; } = false;
    public bool IsPaused { get; private set; } = false;


    private void Awake()
    {
       
    }

    private void OnDestroy()
    {
       
    }

    private void SetGameToWon()
    {
        GameWon = true;
    }

    public void Run()
    {
        IsPaused = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        IsPaused = true;
        Time.timeScale = 0f;
    }
}
