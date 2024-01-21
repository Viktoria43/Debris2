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
    public GameObject gameOver;
    private SpriteRenderer gameOverVis;
    private int spawnCount;
    
    // Start is called before the first frame update
    void Start()
    {
        textureManager = GetComponent<TextureManager>();
        spawnCount = 0;
        spawnRandom();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOverVis == null){
            gameOverVis = gameOver.GetComponent<SpriteRenderer>();
            gameOverVis.enabled = false;
        }else if(gameOverVis.enabled == false){
            if (mv.hasCollided )
            {
                spawnRandom();
                //this is for debugging
                /*
                if(Input.GetKeyDown(KeyCode.S)){
                    curObj = Instantiate(patO, new Vector3(0f, 9.5f, 0f), Quaternion.identity);
                    AssignRandomTexture(curObj);
                }*/
            }
        }else{
            if(spawnCount < 7){
                spawnCount++;
                spawnRandom();
            }
        }

    }
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
       // curObj = Instantiate(patO, new Vector3(0.5f, 7.5f, 0f), Quaternion.identity);
        
       int patNum = rd.Next(0, 7);
        switch (patNum)
        {
            case 0:
                curObj = Instantiate(patI, new Vector3(0.5f, 6.5f, 0f), Quaternion.identity);
                break;
            case 1:
                curObj = Instantiate(patL, new Vector3(0.5f, 6.5f, 0f), Quaternion.identity);
                break;
            case 2:
                curObj = Instantiate(patO, new Vector3(0.5f, 7.5f, 0f), Quaternion.identity);
                break;
            case 3:
                curObj = Instantiate(patRevL, new Vector3(0.5f, 6.5f, 0f), Quaternion.identity);
                break;
            case 4:
                curObj = Instantiate(patRevZ, new Vector3(0.5f, 7.5f, 0f), Quaternion.identity);
                break;
            case 5:
                curObj = Instantiate(patT, new Vector3(0.5f, 7.5f, 0f), Quaternion.identity);
                break;
            case 6:
                curObj = Instantiate(patZ, new Vector3(0.5f, 7.5f, 0f), Quaternion.identity);
                break;
            default:
                break;
        }
        mv = curObj.GetComponent<PlayerMovement>();
        rb = curObj.GetComponent<Rigidbody2D>();
        sr = curObj.GetComponent<SpriteRenderer>();
        rb.velocity = new Vector3(0f, -0.5f, 0f);
        AssignRandomTexture(curObj);
    }
}
