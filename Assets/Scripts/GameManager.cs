using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        } else {
            Time.timeScale = 1;

        }
    }
}
