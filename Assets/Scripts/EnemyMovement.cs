using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float angularSpeed = 1f;
    public float circleRad = 1f;

    private Vector2 fixedPoint;
    private float currentAngle; 

    public float Cos;
    public float Sin;

    public Transform[] points;
    //int currentPointIndex = 0; 


    void Start()
    {

        fixedPoint = this.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle += angularSpeed * Time.deltaTime; 
        Vector2 offset = new Vector2(Mathf.Sin(Sin), Mathf.Cos(Cos)) * circleRad;
        //Vector2 offset = new Vector2(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle)) * circleRad;
        transform.position = fixedPoint + offset; 
    }
}
