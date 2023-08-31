using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyMovement : MonoBehaviour
{
    GameObject ObjToFollow;
    public float speed;
    int direction = 1;
    Vector3 velocity; 
    Vector3 movement;

    //float directionTimer = 0;
    public float maxDirectionTimer = 2;

    public Transform[] points;
    int currentPointIndex = 0;
    bool followActive = false; 

    // Start is called before the first frame update
    void Start()
    {
        ObjToFollow = GameManager.Instance.Player;
        velocity = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if(followActive)
        {
            if(ObjToFollow.transform.position.x <= transform.position.x)
            {
                direction = -1; 
            }
            else if (ObjToFollow.transform.position.x >= transform.position.x)
            {
                direction = 1;
            }
            transform.position += velocity * direction * speed * Time.deltaTime;
        }
        else
        {
            if (points.Length != 0)
            {
                if (Vector2.Distance(transform.position, points[currentPointIndex].position) <= 0.2f)
                {
                    if (currentPointIndex == points.Length - 1)
                    {
                        currentPointIndex = 0;
                    }
                    else
                        currentPointIndex++;
                }

                transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex].position, speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            followActive = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            followActive = false;
        }
    }
}
