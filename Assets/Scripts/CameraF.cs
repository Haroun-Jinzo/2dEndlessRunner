using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraF : MonoBehaviour
{
    public Transform player;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + 6, player.position.y + 3, -10);
        
    }
}
