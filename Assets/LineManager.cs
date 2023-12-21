using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time % 2 < 1f){
            List<Collider2D> colObjs = new List<Collider2D>();
            Physics2D.GetContacts(GetComponent<Collider2D>(), colObjs);
            foreach(Collider2D e in colObjs){
                if (e.gameObject != null) {
                    LineForm lineForm = e.gameObject.GetComponent<LineForm>();
                    if (lineForm != null) {
                        List<GameObject> l = new List<GameObject>(){this.gameObject};
                        bool isLine = false;
                        Debug.Log("Contact " + colObjs.IndexOf(e));
                        isLine = lineForm.lineForming(l, this.gameObject.GetComponent<SpriteRenderer>().color);
                        if(isLine){
                            //destroyObjs(l);
                        }
                    }
                }
            }
        }
        
    }
}
