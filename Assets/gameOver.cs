using UnityEngine;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{
    public Image image;            // Reference to the Image component for displaying the image
    public Button restart;         // Reference to the restart button

    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component

    private void Start()
    {
        // Disable the Image component and restart button at the start
        image.gameObject.SetActive(false);
        restart.interactable = false;

        // Get the SpriteRenderer component attached to the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("YourCollisionTag") && !restart.interactable)
        {
            // Disable the SpriteRenderer component and enable the Image component and restart button
            spriteRenderer.enabled = false;
            image.gameObject.SetActive(true);
            restart.interactable = true;
        }
    }

    public void OnRestartButtonClick()
    {
        // Add code to handle the restart button click
        Debug.Log("Restart Button Clicked");
    }
}