using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float gravityScale = 0.1f;
    public float speedRateIncrease = 0.1f;
    public float speed = 0.01f;
    public bool hasCollided = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        if (IsFalling() && !hasCollided)
        {
            rb.gravityScale = gravityScale + speedRateIncrease * Time.time;
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }

    public bool IsFalling()
    {
        float velocityThreshold = 0.1f;
        return Mathf.Abs(rb.velocity.y) > velocityThreshold;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("LeftBorder") && !collision.collider.CompareTag("RightBorder"))
        {
            hasCollided = true;
            // Your collision logic here
        }
    }
}