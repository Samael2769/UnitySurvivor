using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        speed = gameObject.GetComponent<EnemyHandler>().stats.speed;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
