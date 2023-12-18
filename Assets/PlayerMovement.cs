using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        // Assuming the script is attached to a GameObject with a Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }
    public float speed = 1f;
    public bool hasCollided = false;
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;
        if (IsFalling() && !hasCollided)
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
    private void OnCollisionEnter2D(Collision2D collision){
        if(!collision.collider.CompareTag("LeftBorder") && !collision.collider.CompareTag("RightBorder")){
            hasCollided = true;
            //GetComponent<Variables>().collided = true;
            //idea: create RigidBody2D for every child in code here, then handle all objects
            //independently. Recursive function for checking if a line is formed: 
            //called from LeftBorder and ends at RightBorder (true) or till no other block (false)
        }
    }
    //i can eventually do another script for that, but its easier like this so first 
    //i will have to see if it even works
}