using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodeBeispiel : MonoBehaviour
{
    public GameObject cube;
    bool doOnce = true;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            CreatingCubes();
        }
    }

    void CreatingCubes()
    {
        if(doOnce)
        {
            for (int i = 0; i <= 8; i += 1)
            {
                GameObject newCube = Instantiate(cube);
                newCube.transform.position = new Vector2(newCube.transform.position.x + i, newCube.transform.position.y);
            }
            doOnce = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CreatingCubes();
    }


}
