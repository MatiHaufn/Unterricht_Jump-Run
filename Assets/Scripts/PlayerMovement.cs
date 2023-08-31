using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int direction;
    Vector3 velocity;
    Rigidbody2D myRigidbody;

    public Collider2D GroundCollider;
    bool isGrounded = false;

    public float speed;
    public float multiplicator = 1;
    public float jumpforce;
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;

    public KeyCode shoot;
    [HideInInspector] public int shootCounter = 5;

    public Animator animator;
    float currentSpeed;

    public void SpeedBoost()
    {
        multiplicator++;
    }
    // Start is called before the first frame update
    void Start()
    {
        shootCounter = GameManager.Instance.maxShots;
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        velocity = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = 0;
        if (Input.GetKey(left))
        {
            direction = -1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey(right))
        {
            direction = 1;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        currentSpeed = speed * Mathf.Abs(direction);
        animator.SetFloat("Speed", currentSpeed);

        transform.position += velocity * direction * Time.deltaTime * multiplicator;
    }
    private void Update()
    {
        if (Input.GetKeyDown(up) && isGrounded == true)
        {
            myRigidbody.velocity = Vector2.up * jumpforce;
            // myRigidbody.AddForce(new Vector2(0, jumpforce));
            animator.SetBool("isJumping", true);
            isGrounded = false;
        }

        if (Input.GetKeyDown(shoot) && shootCounter > 0)
        {
            GameObject newProjectile = Instantiate(GameManager.Instance.Projectile);
            newProjectile.transform.position = this.transform.position;
            shootCounter--;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        animator.SetBool("isJumping", false);

        if (other.gameObject.tag == "Enemy")
        {
            if(GameManager.Instance.LifePoints > 1)
            { 
                GameManager.Instance.LifePoints--;
                GameManager.Instance.UpdateHearts(); 
            }
            else
            {
                GameManager.Instance.LifePoints--;
                GameManager.Instance.Respawn(); 
            }
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            //Debug.Log("Ground");
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "checkpoint")
        {
            Debug.Log("checked");
            collision.gameObject.GetComponent<SpriteRenderer>().color = new UnityEngine.Color(1, 1, 1); 
            GameManager.Instance.lastCheckpoint = collision.gameObject; 
        }

        if(collision.tag == "death")
        {
            GameManager.Instance.Respawn(); 
        }
    }
}
