using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FackelMechanic : MonoBehaviour
{
    public GameObject Light; 
    private void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        Light.SetActive(false);
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.tag == "playerSchuss")
        {
            Debug.Log("Treffer");
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            
            if(Light.activeSelf == false)
                Destroy(other.gameObject);
           
            Light.SetActive(true);
        }
    }
    
}
