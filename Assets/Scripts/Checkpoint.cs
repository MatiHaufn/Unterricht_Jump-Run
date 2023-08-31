using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [HideInInspector] public Color color; 

    [HideInInspector] public bool activated = false; 

    void Start()
    {
        color = new Color(0.3f, 0.5f, 1f);
    }
}
