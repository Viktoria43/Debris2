using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineForm : MonoBehaviour
{
    public bool marked;
    private PlayerMovement mv;
    GameObject instance;
    int countBug = 0;
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
            //gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
    }
    private void OnCollisionStay2D(Collision2D collision){
        /*
        if(collision.collider.CompareTag("LeftBorder")){
            List<GameObject> l = new List<GameObject>(){this.gameObject};
            bool isLine = false;
            isLine = lineForming(l, this.gameObject.GetComponent<SpriteRenderer>().color);
            if(isLine){
                destroyObjs(l);
            }
        }*/
    }
    //Idea: return bool for destroyed or not, destroy in method
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
                    if(lineForm.marked){
                        
                    }else{
                        //Debug.Log("I am object " + colObjs.IndexOf(e) + e.gameObject.tag);
                        lineForm.marked = true;
                        line.Add(e.gameObject);
                        lineForm.lineForming(line, col);
                    }
                }
            }
            
            if(e.gameObject.tag != "LeftBorder" && e.gameObject.tag != "Floor"){
            //Destroy(e.gameObject);
            }
        }
        /*
        for(int i = colNum-1;i >= 0;--i){
            if(colObjs[i].CompareTag("RightBorder")){
                //destroy here
                marked = false;
                Debug.Log("Fuckkkkkkkkkkkk");
                return true;
                //assuming that the borders have different colors... hoo boi, this can break so hard
            }else if(colObjs[i].gameObject.GetComponent<LineForm>().marked || col != colObjs[i].gameObject.GetComponent<SpriteRenderer>().color){
                countBug++;
                Debug.Log(countBug);
                colObjs.RemoveAt(i);
            }else if(!colObjs[i].gameObject.GetComponent<LineForm>().marked){
                
                Debug.Log("Nooooooooooooooooo");
                line.Add(colObjs[i].gameObject);
                return lineForming(line, col);
            }
        }*/
        //marked = false;
        return false;
    }
    private void destroyObjs(List<GameObject> list){
        foreach(GameObject e in list){
            Destroy(e);
        }
    }
}
