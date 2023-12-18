using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineForm : MonoBehaviour
{
    public bool marked;
    private PlayerMovement mv;
    // Start is called before the first frame update
    void Start()
    {
        mv = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision){
        if(collision.collider.CompareTag("LeftBorder")){
            List<GameObject> l = new List<GameObject>(){collision.gameObject};
            bool isLine = false;
            isLine = lineForming(l, collision.gameObject.GetComponent<SpriteRenderer>().color);
            if(isLine){
                destroyObjs(l);
            }
        }
    }
    //Idea: return bool for destroyed or not, destroy in method
    private bool lineForming(List<GameObject> line, Color col){
        List<Collider2D> colObjs = new List<Collider2D>();
        ContactFilter2D fil = new();
        fil.NoFilter();
        int colNum = Physics2D.OverlapCircle(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), 1f, 
                                fil, colObjs);
        for(int i = colNum-1;i >= 0;--i){
            if(colObjs[i].CompareTag("RightBorder")){
                //destroy here
                return true;
                //assuming that the borders have different colors... hoo boi, this can break so hard
            }else if(colObjs[i].gameObject.GetComponent<LineForm>().marked || col != colObjs[i].gameObject.GetComponent<SpriteRenderer>().color){
                colObjs.RemoveAt(i);
            }else if(!colObjs[i].gameObject.GetComponent<LineForm>().marked){
                marked = true;
                line.Add(colObjs[i].gameObject);
                return lineForming(line, col);
            }
        }
        /*
        foreach(Collider2D col2d in colObjs){
            
            if(col2d.CompareTag("RightBorder")){
                //destroy here
                return true;
                //assuming that the borders have different colors... hoo boi, this can break so hard
            }else if(col2d.gameObject.GetComponent<LineForm>().marked || col != col2d.gameObject.GetComponent<SpriteRenderer>().color){
                colObjs.Remove(col2d);
            }else if(!col2d.gameObject.GetComponent<LineForm>().marked){
                line.Add(col2d.gameObject);
                return lineForming(line, col);
            }
            //but somewhere it has to remove from list
        }*/
        return false;
    }
    private void destroyObjs(List<GameObject> list){
        foreach(GameObject e in list){
            Destroy(e);
        }
    }
}
