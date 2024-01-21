using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float gravityScale = 0.1f;
    public float speedRateIncrease = 0.001f;
    public float speed = 0.1f;
    public float moveSpeed = 2f;
    public bool hasCollided = false;
    private Rigidbody2D rb;
    private int leftCount = 0;
    private int rightCount = 0;
    
   // bool rotation = false;
    int rotation = 0;
    int isTriggered = 0;
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
            //testing
            rb.gravityScale = gravityScale + speedRateIncrease * ((int)Time.time / 30);
            //transform.Translate(movement * speed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //rotation = !rotation;
                rotation++;
                if(rotation == 5)
                {
                    rotation =0;
                }
                Debug.Log(rotation);
                transform.Rotate(Vector3.forward, 90f);
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow) && isTriggered != -1 && rotation%2 == 0)
            {
                transform.Translate(transform.TransformDirection(Vector3.left) * 1f);
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow) && isTriggered != -1 && rotation%2 == 1)
            {
                transform.Translate(transform.TransformDirection(Vector3.right) * 1f);
            }
            if(Input.GetKeyDown(KeyCode.RightArrow) && isTriggered != 1 && rotation%2 == 0)
            {
                transform.Translate(transform.TransformDirection(Vector3.right) * 1f);
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow) && isTriggered != 1 && rotation%2 == 1)
            {
                transform.Translate(transform.TransformDirection(Vector3.left) * 1f);
            }
            /*
            if (Input.GetKeyDown(KeyCode.LeftArrow) && rotation%2 == 0 && leftCount <= 5)
            {
                if (rotation == 2 && leftCount <= 4){
                    leftCount++;
                    rightCount--;
                    transform.Translate(transform.TransformDirection(Vector3.left) * 1f);
                }
                else if (rotation == 4 || rotation == 0 && leftCount <= 5)
                {
                    leftCount++;
                    rightCount--;
                    transform.Translate(transform.TransformDirection(Vector3.left) * 1f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && rotation%2 == 1)
            {
                if (rotation == 1 && leftCount <= 4){
                    leftCount++;
                    rightCount--;
                    transform.Translate(transform.TransformDirection(Vector3.right) * 1f);
                }
                else if (rotation == 3 && leftCount <= 5){
                    leftCount++;
                    rightCount--;
                    transform.Translate(transform.TransformDirection(Vector3.right) * 1f);
                }
               
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && rotation%2 == 0)
            {

                if ((rotation == 0 || rotation == 4) && rightCount <= 3){
                    rightCount++;
                    leftCount--;
                    Debug.Log(rightCount);
                    transform.Translate(transform.TransformDirection(Vector3.right) * 1f);
                }
                else if (rotation == 2 && rightCount <= 4){
                    rightCount++;
                    leftCount--;
                    transform.Translate(transform.TransformDirection(Vector3.right) * 1f);
                }
               
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && rotation%2 == 1)
            {
                if (rotation == 1 && rightCount <= 4){
                    rightCount++;
                    leftCount--;
                    transform.Translate(transform.TransformDirection(Vector3.left) * 1f);
                }
                else if (rotation ==3&& rightCount<=3){
                    rightCount++;
                    leftCount--;
                    transform.Translate(transform.TransformDirection(Vector3.left) * 1f);
                }
            }
            */
            if (Input.GetKeyDown(KeyCode.DownArrow) && rotation%2 == 0)
            {
                transform.Translate(transform.TransformDirection(Vector3.down) * 1f);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && rotation%2 == 1)
            {
                transform.Translate(transform.TransformDirection(Vector3.up) * 1f);
            }
        }
    }
    

    public bool IsFalling()
    {
        float velocityThreshold = 0.1f;
        return Mathf.Abs(rb.velocity.y) > velocityThreshold;
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        if(gameObject.transform.position.x > collision.gameObject.transform.position.x){
            isTriggered = -1;
        }else if(gameObject.transform.position.x < collision.gameObject.transform.position.x){
            isTriggered = 1;
        }else{
            isTriggered = 0;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision){
        if(gameObject.transform.position.x > collision.gameObject.transform.position.x){
            isTriggered = -1;
        }else if(gameObject.transform.position.x < collision.gameObject.transform.position.x){
            isTriggered = 1;
        }else{
            isTriggered = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        isTriggered = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (!collision.collider.CompareTag("LeftBorder") && !collision.collider.CompareTag("RightBorder"))
        {
            hasCollided = true;
            List<Transform> children = new List<Transform>();
            
            if(gameObject.transform.childCount != 0){
                children.Add(gameObject.transform.GetChild(0));
                children.Add(gameObject.transform.GetChild(1));
                children.Add(gameObject.transform.GetChild(2));
            }
            foreach(Transform child in children){
                Rigidbody2D rb = child.gameObject.GetComponent<Rigidbody2D>();
                // If the Rigidbody component doesn't exist, add it
                if (rb == null)
                {
                    rb = child.gameObject.AddComponent<Rigidbody2D>();
                    // Customize the Rigidbody properties if needed
                    rb.gravityScale = 0.1f; // For example, set the gravity scale
                    rb.velocity = GetComponent<Rigidbody2D>().velocity;
                    rb.freezeRotation = true;
                }
            }
            this.gameObject.transform.DetachChildren();
        }
    }
}