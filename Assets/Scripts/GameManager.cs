using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public GameObject gameOverPanel;

    private static int score = 0;

    [SerializeField] private TextMeshProUGUI[] scoreTexts;

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

        // Increase the score every second
        score = (int)Time.timeSinceLevelLoad;
        foreach (TextMeshProUGUI scoreText in scoreTexts)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
