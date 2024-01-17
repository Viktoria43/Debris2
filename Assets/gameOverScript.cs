using UnityEngine;
using UnityEngine.UI;

public class gameOverScript : MonoBehaviour
{
    public Button restart;
    public Button Quit;
    public GameObject gameOver;
 

    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        restart.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
        spriteRenderer = gameOver.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        restart.gameObject.SetActive(true);
        Quit.gameObject.SetActive(true);
        gameOver.SetActive(true);
        spriteRenderer.enabled = true;
       
    }

  
}