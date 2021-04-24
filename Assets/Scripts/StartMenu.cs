using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject StartMenuUI;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        ShowStartMenu();
    }

    public void ShowStartMenu()
    {
        StartMenuUI.SetActive(true);
        _gameManager.Pause();
    }

    public void StartGame()
    {
        StartMenuUI.SetActive(false);
        _gameManager.Run();
    }

}
