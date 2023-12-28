using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;


public class spawn : MonoBehaviour
{
    public TextureManager textureManager;
    public GameObject patT;
    public GameObject patL;
    public GameObject patZ;
    public GameObject patO;
    public GameObject patRevL;
    public GameObject patRevZ;
    public GameObject patI;
    private GameObject curObj;
    PlayerMovement mv;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        textureManager = GetComponent<TextureManager>();
        spawnRandom();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mv.hasCollided )
        {
            //mv.hasCollided = true;
            //spawnRandom();
            //this is for debugging
            if(Input.GetKeyDown(KeyCode.S)){
                curObj = Instantiate(patO, new Vector3(0f, 9.5f, 0f), Quaternion.identity);
                AssignRandomTexture(curObj);
            }
           
        }

    }
    /*
    private void OnCollisionEnter2D(Collision2D collision){
        //so far detects only if the parent object collided
        //Variables.Object(collision.gameObject).Get("hasCollided");
        if (!hasCollided)
        {
            // Get the collision point and instantiate the object there
            hasCollided = true;
            sp.spawnRandom();
        }
    }*/
    //This is called, when collision between the calling object and other object happens
    /*private void OnCollisionEnter2D(Collision2D collision){
        //so far detects only if the parent object collided
        //Variables.Object(collision.gameObject).Get("hasCollided");
        bool check = collision.gameObject.GetComponent<commonVars>().hasCollided;
        if (!check && collision.gameObject.CompareTag("Block"))
        {
            // Get the collision point and instantiate the object there
            collision.gameObject.GetComponent<commonVars>().hasCollided = true;
          //  collision.gameObject.SetActive(false);
            spawnRandom();
        }
    }*/
    void AssignRandomTexture(GameObject obj)
    {
        if (textureManager != null)
        {
            // Assuming that the TextureManager has a method to assign random textures
            textureManager.AssignRandomTexture(obj);
        }
        else
        {
            Debug.LogError("TextureManager is not assigned.");
        }
    }
    public void spawnRandom()
    {
        System.Random rd = new System.Random();
        //for testing
     // curObj = Instantiate(patI, new Vector3(0f, 9.5f, 0f), Quaternion.identity);
        
        int patNum = rd.Next(0, 7);
        switch (patNum)
        {
            case 0:
                curObj = Instantiate(patI, new Vector3(0f, 9.5f, 0f), Quaternion.identity);
                break;
            case 1:
                curObj = Instantiate(patL, new Vector3(0f, 9.5f, 0f), Quaternion.identity);
                break;
            case 2:
                curObj = Instantiate(patO, new Vector3(0f, 9.5f, 0f), Quaternion.identity);
                break;
            case 3:
                curObj = Instantiate(patRevL, new Vector3(0f, 9.5f, 0f), Quaternion.identity);
                break;
            case 4:
                curObj = Instantiate(patRevZ, new Vector3(0f, 9.5f, 0f), Quaternion.identity);
                break;
            case 5:
                curObj = Instantiate(patT, new Vector3(0f, 9.5f, 0f), Quaternion.identity);
                break;
            case 6:
                curObj = Instantiate(patZ, new Vector3(0f, 9.5f, 0f), Quaternion.identity);
                break;
            default:
                break;
        }
        mv = curObj.GetComponent<PlayerMovement>();
        rb = curObj.GetComponent<Rigidbody2D>();
        sr = curObj.GetComponent<SpriteRenderer>();
        rb.velocity = new Vector3(0f, -0.5f, 0f);
        int colNum = rd.Next(0,3);
      //  sr.color = Color.red;
        /*
        switch(colNum){
            case 0:
                sr.color = Color.red;
                break;
            case 1:
                sr.color = Color.blue;
                break;
            case 2:
                sr.color = Color.green;
                break;
            default: 
                break;
        }*/
        //the lazy dumb way
        curObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = sr.color;
        curObj.transform.GetChild(1).GetComponent<SpriteRenderer>().color = sr.color;
        curObj.transform.GetChild(2).GetComponent<SpriteRenderer>().color = sr.color;
        AssignRandomTexture(curObj);
    }
}
