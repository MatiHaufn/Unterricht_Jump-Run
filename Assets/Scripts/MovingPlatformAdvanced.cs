using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatformAdvanced : MonoBehaviour
{
    public float speed;

    public Transform[] points;
    int currentPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {   
        if(points.Length != 0)
            transform.position = points[0].transform.position; 

        foreach (Transform point in points)
        {
            point.gameObject.GetComponent<SpriteRenderer>().enabled = false; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentPointIndex);
        //Debug.Log("current Index: " + currentPointIndex);
        if(points.Length != 0)
        {
            if(Vector2.Distance(transform.position, points[currentPointIndex].position) <= 0.2f)
            {
                if(currentPointIndex == points.Length - 1)
                {
                    currentPointIndex = 0; 
                }
                else 
                    currentPointIndex++; 
            }

            transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex].position, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }
}
