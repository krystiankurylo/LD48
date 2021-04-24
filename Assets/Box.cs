using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{   
    [SerializeField]
    private GameObject uiText;

    [SerializeField]
    private GameObject uiPanel;

    [SerializeField]
    private GameObject winPanel;

    private bool withCollistion;
    
    private bool winPanelHidden;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            uiPanel.SetActive(true);
            uiPanel.SetActive(true);

            withCollistion = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            uiPanel.SetActive(false);
            uiPanel.SetActive(false);

            withCollistion = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && withCollistion)
        {
            uiPanel.SetActive(false);
            uiPanel.SetActive(false);
            winPanel.SetActive(true);
            StartCoroutine(HideWinPanel());
        }
    }

    private IEnumerator HideWinPanel()
    {
        while (!winPanelHidden)
        {
            yield return new WaitForSeconds(5f);

            winPanel.SetActive(false);
            winPanelHidden = true;
            SceneManager.LoadScene("Menu");
        }
    }
}
