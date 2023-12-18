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
        
    }
    private void OnCollisionStay2D(Collision2D collision){
        if(collision.collider.CompareTag("LeftBorder")){
            List<GameObject> l = new List<GameObject>(){instance};
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
                marked = false;
                Debug.Log("Fuckkkkkkkkkkkk");
                return true;
                //assuming that the borders have different colors... hoo boi, this can break so hard
            }else if(colObjs[i].gameObject.GetComponent<LineForm>().marked || col != colObjs[i].gameObject.GetComponent<SpriteRenderer>().color){
                countBug++;
                Debug.Log(countBug);
                colObjs.RemoveAt(i);
            }else if(!colObjs[i].gameObject.GetComponent<LineForm>().marked){
                marked = true;
                Debug.Log("Nooooooooooooooooo");
                line.Add(colObjs[i].gameObject);
                return lineForming(line, col);
            }
        }
        return false;
    }
    private void destroyObjs(List<GameObject> list){
        foreach(GameObject e in list){
            Destroy(e);
        }
    }
}
