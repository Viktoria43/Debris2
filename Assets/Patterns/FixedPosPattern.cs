using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPosPattern : MonoBehaviour
{
    private List<Vector3> chPos;
    //private List<Quaternion> chRot;
    // Start is called before the first frame update
    void Start()
    {
        chPos = new();
        //chRot = new();
        foreach(Transform child in transform){
            chPos.Add(new Vector3(child.localPosition.x, child.localPosition.y));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 parPos = new(){x = transform.position.x, y = transform.position.y, 
        z = transform.position.z};
        int chCount = transform.childCount;
        Transform child;
        for(int i = 0;i < chCount;i++){
            child = transform.GetChild(i);
            child.position = chPos[i]/2 + parPos;
            child.localRotation = transform.localRotation;
            child.rotation = transform.rotation;
        }
    }
}
