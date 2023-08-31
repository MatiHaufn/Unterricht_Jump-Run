using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class GridManager : MonoBehaviour
{
    public GameObject Tile;
    public int tileWidth = 1;
    public int tileHeight = 1; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateTiles() 
    { 
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                GameObject newTile = Instantiate(Tile); 

            }
        }
    }
}
