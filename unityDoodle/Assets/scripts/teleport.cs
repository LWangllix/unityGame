using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class teleport : MonoBehaviour
{

    public bool side=false;
   
    void OnTriggerEnter2D(Collider2D other) {
        if(!side)
        other.gameObject.transform.position=new Vector2(-4f,other.gameObject.transform.position.y);
        else
        other.gameObject.transform.position=new Vector2(4f,other.gameObject.transform.position.y);
    }
}
