using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform tr;
  
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();  
    }

}
