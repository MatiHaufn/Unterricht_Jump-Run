using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeCrystal : MonoBehaviour
{
    public GameObject Light;
    float cooldown = 5;
    public int secondsCooldown = 5;

    Color maxColor = new Color(0.4f, 0.8f, 0.2f);
    public Color color;
    Color startColor = Color.black;

    float lerpTimeValue;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        Light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;

        if (cooldown >= secondsCooldown)
        {
            color = maxColor;
        }
        else
        {
            if (color != maxColor)
            {
                lerpTimeValue += Time.deltaTime / secondsCooldown;
                color = Color.Lerp(startColor, maxColor, lerpTimeValue);
            }
        }

        this.gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.gameObject.GetComponent<PlayerMovement>().shootCounter != GameManager.Instance.maxShots)
        {
            if (cooldown >= secondsCooldown)
            {
                Light.SetActive(true);
                collision.gameObject.GetComponent<PlayerMovement>().shootCounter = GameManager.Instance.maxShots;
                color = startColor;
                lerpTimeValue = 0;
                cooldown = 0;
            }
        }
    }
}
