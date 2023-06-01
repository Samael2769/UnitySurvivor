using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInfo : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    [SerializeField] public float damage = 10f;
    [SerializeField] public float recastTime = 0.5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision" + other.gameObject.tag);
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
