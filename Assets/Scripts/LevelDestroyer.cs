using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroyer : MonoBehaviour
{
    private Vector3 DestroyPosition;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Level")
        {
           Destroy(GameObject.FindWithTag("Level"));
        }
    }
    

}