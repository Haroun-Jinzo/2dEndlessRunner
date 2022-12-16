using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    private Vector3 dist;

    void Start()
    {
        dist = new Vector3(0, +6, 0);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position-dist, speed * Time.deltaTime);
    }
}
