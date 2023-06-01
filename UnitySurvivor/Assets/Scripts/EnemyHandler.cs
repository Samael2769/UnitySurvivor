using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public GameObject enemyType;
    public EnemyStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = enemyType.GetComponent<EnemyStats>();
        Debug.Log("Enemy health: " + stats.health);
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        stats.health -= damage;
        Debug.Log("Enemy health: " + stats.health);
    }

    public void Attack(GameObject target)
    {
        target.GetComponent<Movement>().TakeDamage(stats.damage);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision with enemy and " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            Attack(other.gameObject);
        } else if (other.gameObject.tag == "Shoot")
        {
            TakeDamage(10);
        }
    }
}
