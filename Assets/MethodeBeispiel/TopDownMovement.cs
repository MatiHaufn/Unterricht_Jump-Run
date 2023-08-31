using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    float horizontal; 
    float vertical;

    Vector3 movement;
    public float speed = 3; 


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movement = new Vector2(horizontal * speed, vertical * speed) * Time.deltaTime;
        transform.position += movement; 
    }
}
