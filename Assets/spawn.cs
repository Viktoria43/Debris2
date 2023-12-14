using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject patT;
    public GameObject patL;
    public GameObject patZ;
    public GameObject patO;
    public GameObject patRevL;
    public GameObject patRevZ;
    public GameObject patI;
    //public GameObject curObj;
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
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //so far detects only if the parent object collided
        if (collision.gameObject.CompareTag("Block"))
        {
            // Get the collision point and instantiate the object there
            collision.gameObject.SetActive(false);
            spawnRandom();
        }
    }
    public void spawnRandom(){
        System.Random rd = new System.Random();
        int patNum = rd.Next(0, 7);
        switch (patNum)
        {
            case 0:
                Instantiate(patI, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
                break;
            case 1:
                Instantiate(patL, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
                break;
            case 2:
                Instantiate(patO, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
                break;
            case 3:
                Instantiate(patRevL, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
                break;
            case 4:
                Instantiate(patRevZ, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
                break;
            case 5:
                Instantiate(patT, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
                break;
            case 6:
                Instantiate(patZ, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
                break;
            default:
                break;
        }
    }
}
