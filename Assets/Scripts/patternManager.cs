using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patternManager : MonoBehaviour
{
    public int numberPattern;
    // Start is called before the first frame update
    void Awake()
    {
        numberPattern = transform.childCount;
    }
}
