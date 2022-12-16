using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSplit : MonoBehaviour
{

    public float screenWidth;
    public Transform player;
    public static ScreenSplit inst;

    void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + 4.4f, transform.position.z);
    }
}
