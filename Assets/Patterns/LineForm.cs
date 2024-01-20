using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineForm : MonoBehaviour
{
    public bool marked;
    public bool touchesLeft;
    private PlayerMovement mv;
    GameObject instance;
    Rigidbody2D rb;
   // int countBug = 0;
    // Start is called before the first frame update
    void Start()
    {
        mv = gameObject.GetComponent<PlayerMovement>();
        instance = gameObject;
        touchesLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.time % 2f < 1f){
            marked = false;
        }
        if(touchesLeft){
            List<GameObject> l = new List<GameObject>(){this.gameObject};
            bool isLine = false;
            //Debug.Log("Contact " + colObjs.IndexOf(e));
            isLine = lineForming(l, this.gameObject.GetComponent<SpriteRenderer>().sprite, false);
            if(isLine){
                destroyObjs(l);
            }
        }
        touchesLeft = false;
        //maybe make a check for == 0 to optimize?...
        if(Time.time % 1f < 1f){
            rb = GetComponent<Rigidbody2D>();
            if(rb != null){
                rb.WakeUp();
            }
        }
    }
    public bool lineForming(List<GameObject> line, Sprite col, bool reachedEnd){
        marked = true;
        //bool reachedEnd = false;
        List<Collider2D> colObjs = new List<Collider2D>();
        int colNum = Physics2D.GetContacts(GetComponent<Collider2D>(), colObjs);
        foreach(Collider2D e in colObjs){
            if (e.gameObject != null) {
                LineForm lineForm = e.gameObject.GetComponent<LineForm>();
                if (lineForm != null) {
                    if(!lineForm.marked && lineForm.gameObject.GetComponent<SpriteRenderer>().sprite == col){
                        //lineForm.marked = true;
                        Debug.DrawLine(transform.position, e.gameObject.transform.position, Color.red, 3f);
                        line.Add(e.gameObject);
                        //change the value in a boolean variable for the different lines. 
                        //return lineForm.lineForming(line, col);
                        reachedEnd = reachedEnd || lineForm.lineForming(line, col, reachedEnd);
                    }
                }else if(e.gameObject.CompareTag("RightBorder")){
                    reachedEnd = true;
                    //return true;
                }
            }
        }
        //marked = false;
        return reachedEnd;
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("LeftBorder")){
            touchesLeft = true;
        }
    }

    private void destroyObjs(List<GameObject> list){
        foreach(GameObject e in list){
            Destroy(e);
        }
    }
}
