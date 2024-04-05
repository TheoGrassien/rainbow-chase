using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    [SerializeField] private GameObject[] PatternPrefabs;

    private float zSpawn = 10;

    private readonly float patternLength = 10;

    [SerializeField] private int numberOfPatterns = 3;
    [SerializeField] private float speed = 5.0f;

    [SerializeField] private float speedIncrease = 0.005f;

    private GameObject lastPattern; // Keep track of the last generated pattern
     
    // Start is called before the first frame update
    void Start()
    {
        // Generate the first 3 patterns
        for (int i = 0; i < numberOfPatterns; i++)
        {
            GeneratePattern();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePattern();
        RemovePattern();
        SpeedUp();

        // Generate new pattern when the last pattern's z is less than patternLength * 2
        // NB: We add an extra 1 to the z position to prevent little gaps between patterns
        if (lastPattern.transform.position.z < patternLength * 2 + 1)
        {
            // Reset zSpawn to prevent the z position from increasing indefinitely
            zSpawn -= patternLength;
            GeneratePattern();
        }
    }

    private void GeneratePattern()
    {
        // Randomly select a pattern from the PatternPrefabs array
        int patternIndex = Random.Range(0, PatternPrefabs.Length);

        lastPattern = Instantiate(PatternPrefabs[patternIndex], new Vector3(0, 0, zSpawn), Quaternion.identity);
        zSpawn += patternLength;
    }

    private void MovePattern()
    {
        foreach (var pattern in GameObject.FindGameObjectsWithTag("Pattern"))
        {
            pattern.transform.position += speed * Time.deltaTime * Vector3.back;
        }
    }

    private void RemovePattern()
    {
        // Get the first pattern in the scene
        GameObject firstPattern = GameObject.FindGameObjectsWithTag("Pattern")[0];

        // Destroy the pattern when its z is less than 2 * patternLength
        if (firstPattern.transform.position.z < -2 * patternLength)
        {
            Destroy(firstPattern);
        }
    }

    private void SpeedUp()
    {
        // Increase the speed over time
        speed += speedIncrease ;
    }
}
