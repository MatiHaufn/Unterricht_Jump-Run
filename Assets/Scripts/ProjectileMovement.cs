using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    public float speed = 1;
    int direction = 0;

    float timer = 0;
    float maxTimer = 5; 

    private void Start()
    {
        if (GameManager.Instance.Player.GetComponent<SpriteRenderer>().flipX == false)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 
        
        transform.position += new Vector3(speed * direction, 0, 0) * Time.deltaTime; 
    
        if(timer >= maxTimer)
        {
            Destroy(this.gameObject);
        }
    }
}
