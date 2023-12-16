using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class spawn : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        spawnRandom();
    }

    // Update is called once per frame
    void Update()
    {
        //do spawn upon collision between objects tagged Block and obj tagged Borders
        //ontriggerenter
        /*
        if(Time.frameCount % 60 == 0){
            spawnRandom();
        }*/
        if (!mv.IsFalling() && !mv.hasCollided)
        {
            mv.hasCollided = true;
            spawnRandom();
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
    public void spawnRandom()
    {
        System.Random rd = new System.Random();
        int patNum = rd.Next(0, 7);
        switch (patNum)
        {
            case 0:
                curObj = Instantiate(patI, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
                break;
            case 1:
                curObj = Instantiate(patL, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
                break;
            case 2:
                curObj = Instantiate(patO, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
                break;
            case 3:
                curObj = Instantiate(patRevL, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
                break;
            case 4:
                curObj = Instantiate(patRevZ, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
                break;
            case 5:
                curObj = Instantiate(patT, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
                break;
            case 6:
                curObj = Instantiate(patZ, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
                break;
            default:
                break;
        }
        mv = curObj.GetComponent<PlayerMovement>();
        rb = curObj.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0f, 0.5f, 0f);
    }
}
