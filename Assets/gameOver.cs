using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    // public Image image;            // Reference to the Image component for displaying the image
    public Button restart; // Reference to the restart button
  
    public Button Quit;
    // public mv = curObj.GetComponent<PlayerMovement>();
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    private void Start()
    {
        // Disable the Image component and restart button at the start
        //  image.gameObject.SetActive(false);
        //restart.interactable = false;
        restart.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);

        // Get the SpriteRenderer component attached to the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /*/  private void OnTriggerEnter(Collider other)
          {
              Debug.LogError(other.CompareTag("Borders"));
              if (other.CompareTag("Borders"))
              {
                  // Disable the SpriteRenderer component and enable the Image component and restart button
                 // spriteRenderer.enabled = false;
               //   image.gameObject.SetActive(true);
                  //restart.interactable = true;
                  Debug.LogError("colis detected");
                  restart.gameObject.SetActive(true);
              }
          }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            restart.gameObject.SetActive(true);
            Quit.gameObject.SetActive(true);
            Debug.Log("colis detected");
        


    }
}