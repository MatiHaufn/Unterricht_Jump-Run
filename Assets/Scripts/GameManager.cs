using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Canvas;

    public GameObject Player;
    public GameObject Projectile;
    public GameObject Shootbar;
    public int maxShots = 5;

    public int LifePoints = 3;
    public Image lifeHeart;
    List<Image> AllHearts = new List<Image>(); 

    public bool CanActivateTorch = false;

    public GameObject lastCheckpoint;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHearts();
    }

    // Update is called once per frame
    void Update()
    {
        Shootbar.gameObject.GetComponent<Slider>().value = Player.GetComponent<PlayerMovement>().shootCounter;
    }

    public void UpdateHearts()
    {
        foreach(Image heart in AllHearts)
        {
            Destroy(heart);
        }

        for(int i = 0; i < LifePoints; i++)
        {
            lifeHeart.gameObject.SetActive(false); 
            Image heart = Instantiate(lifeHeart);
            heart.rectTransform.position = new Vector3(lifeHeart.rectTransform.position.x + i*25, lifeHeart.rectTransform.position.y, 0);
            heart.transform.SetParent(Canvas.transform);
            heart.gameObject.SetActive(true); 
            AllHearts.Add(heart); 
        }
    }

    public void Respawn()
    {
        Player.transform.position = lastCheckpoint.transform.position;
        LifePoints = 3;
    }
}
