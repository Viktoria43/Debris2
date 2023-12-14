using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject somePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(somePrefab, new Vector3(0f, 4.5f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnRandom(){
        System.Random rd = new System.Random();
        int patNum = rd.Next(0, 7);
        switch (patNum)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            default:
                break;
        }
    }
}
