using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{

    public GameObject patternTemplate;
    public GameObject ground;

    private patternManager m_patternManager;
    private float speed = 5.0f;
    private float sizeY = 10;

    void Awake() {
        sizeY = ground.transform.localScale.y;
        m_patternManager = FindObjectOfType<patternManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * speed;

        if (m_patternManager == null)
        {
            return;
        }

        // Generate new pattern when the current pattern is out of the screen
        if (transform.position.z < -sizeY)
        {
            Instantiate(patternTemplate, new Vector3(0, 0, sizeY * (m_patternManager.numberPattern - 1)), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
