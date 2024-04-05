using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class Events : MonoBehaviour
{
    private GameManager m_gameManager;

    private void Start()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (m_gameManager.gameOver)
        {
            // Restart the game when the space key is pressed
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                RestartGame();
            }
        }
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
