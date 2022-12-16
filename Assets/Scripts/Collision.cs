using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCollision : MonoBehaviour
{
   

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision )
    {
        if (collision.CompareTag("sticker"))
        {
            Debug.Log("collision");
        }


    }
}
