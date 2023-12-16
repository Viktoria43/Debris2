using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private spawn sp;
    private GameObject help;
    void Start()
    {
        // Assuming the script is attached to a GameObject with a Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        //what
        help = GameObject.FindGameObjectWithTag("Borders");
        sp = help.GetComponent<spawn>();
    }
    public float speed = 1f;
    public bool hasCollided = false;

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;
        if (IsFalling())
        {
            transform.Translate(movement * speed * Time.deltaTime);
        }
        
    }
    public bool IsFalling()
    {
        // Check if the magnitude of the vertical velocity is greater than a threshold
        // You can adjust the threshold value based on your needs
        float velocityThreshold = 0.1f;
        return Mathf.Abs(rb.velocity.y) > velocityThreshold;
    }
}