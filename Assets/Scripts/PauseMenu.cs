using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	public GameObject PauseMenuUI;

	private GameManager _gameManager;

	[SerializeField]
	private GameObject mainMenu;

	[SerializeField]
	private GameObject optionsMenu;

	private void Awake()
	{
		_gameManager = FindObjectOfType<GameManager>();
	}

	private void Start() { }

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (_gameManager.IsPaused)
			{
				Debug.Log("Resume");
				Resume();
			}
			else
			{
				Debug.Log("Pause");
				Pause();
			}
		}
	}

	public void Resume()
	{
		PauseMenuUI.SetActive(false);
		_gameManager.Run();
	}

	public void Pause()
	{
		PauseMenuUI.SetActive(true);
		ShowMainMenu();

		_gameManager.Pause();
	}

	public void Quit()
	{
		_gameManager.Run();
		SceneManager.LoadScene("Menu");
	}

	void ShowMainMenu()
	{
		mainMenu.SetActive(true);
		optionsMenu.SetActive(false);

		//var menuItems = GameObject.FindGameObjectsWithTag("MenuItem");
		//if (menuItems.Length == 0)
		//{
		//    Debug.Log("no menuitems found");
		//}

		//foreach (var menuItem in menuItems)
		//{
		//    if (menuItem.name == "MainMenu")
		//    {
		//        Debug.Log("MenuItem named " + menuItem.name + " is active");
		//        menuItem.SetActive(true);
		//    }
		//    else
		//    {
		//        Debug.Log("MenuItem named " + menuItem.name + " is not active");
		//        menuItem.SetActive(false);
		//    }
		//}
	}
}
