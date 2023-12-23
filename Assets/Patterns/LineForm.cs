using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineForm : MonoBehaviour
{
    public bool marked;
    private PlayerMovement mv;
    GameObject instance;
   // int countBug = 0;
    // Start is called before the first frame update
    void Start()
    {
        mv = gameObject.GetComponent<PlayerMovement>();
        instance = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time % 2f < 1f){
            marked = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
    }
    public bool lineForming(List<GameObject> line, Color col){
        marked = true;
        if(marked){
            gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        List<Collider2D> colObjs = new List<Collider2D>();
        int colNum = Physics2D.GetContacts(GetComponent<Collider2D>(), colObjs);
        foreach(Collider2D e in colObjs){
            if (e.gameObject != null) {
                LineForm lineForm = e.gameObject.GetComponent<LineForm>();
                if (lineForm != null) {
                    if(!lineForm.marked){
                        //Debug.Log("I am object " + colObjs.IndexOf(e) + e.gameObject.tag);
                        //lineForm.marked = true;
                        line.Add(e.gameObject);
                        return lineForm.lineForming(line, col);
                    }
                }else if(e.gameObject.CompareTag("RightBorder")){
                    return true;
                }
            }
            
            if(e.gameObject.tag != "LeftBorder" && e.gameObject.tag != "Floor"){
            //Destroy(e.gameObject);
            }
        }
        //marked = false;
        return false;
    }
}
