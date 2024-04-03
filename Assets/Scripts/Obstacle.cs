using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Référence au script GameManager
    private GameManager m_gameManager;

    private void Start()
    {
        // Trouver le GameManager dans la scène
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private
  void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'agent entre en collision avec le joueur
        if (other.gameObject.CompareTag("Player"))
        {
            // Appeler la méthode GameOver
            m_gameManager.gameOver = true;
        }

    }
}
