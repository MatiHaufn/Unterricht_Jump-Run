using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed; 

    int direction = 1;
    float maxTimer = 3;
    float timer = 0;
    float movement; 

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;


        if (timer >= maxTimer)
        {
            direction = -direction;
            timer = 0; 
        }
        movement = direction * speed * Time.fixedDeltaTime;
        transform.position = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }
}
