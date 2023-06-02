using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> enemiesTypes = new List<GameObject>();
    public int maxEnemies = 5;
    public int currentEnemies = 0;
    public float spawnTime = 3f;
    public float delay = 2f;
    public int distanceFromPlayer = 15;
    public GameObject player;
    public float speedMultiplier = 1f;
    public int damageAdder = 0;
    public int healthAdder = 0;

    private bool canUpdate = true;


    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", delay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentEnemies = transform.childCount;
        if (score % 10 == 0 && score > 0) {
            if (canUpdate == true) {
                maxEnemies += 2;
                canUpdate = false;
            }
        } else if (score % 15 == 0 && score > 0) {
            if (canUpdate == true) {
                spawnTime -= 0.2f;
                speedMultiplier += 0.1f;
                damageAdder += 2;
                healthAdder += 10;
                canUpdate = false;
            }
        } else if (score % 55 == 0 && score > 0) {
            if (canUpdate == true) {
                player.GetComponent<PlayerShoot>().upgradeWeapon();
            }
        }else {
            canUpdate = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Spawn()
    {
        if (currentEnemies < maxEnemies)
        {
            int enemyIndex = Random.Range(0, enemiesTypes.Count);
            GameObject new_enemy = Instantiate(enemy, new Vector3(Random.Range(-distanceFromPlayer, distanceFromPlayer), Random.Range(-distanceFromPlayer, distanceFromPlayer), 0), Quaternion.identity);
            new_enemy.transform.parent = this.transform;
            GameObject new_enemy_sprite = Instantiate(enemiesTypes[enemyIndex], new_enemy.transform.position, Quaternion.identity);
            new_enemy_sprite.transform.parent = new_enemy.transform;
            new_enemy_sprite.GetComponent<EnemyStats>().health += healthAdder;
            new_enemy_sprite.GetComponent<EnemyStats>().damage += damageAdder;
            new_enemy_sprite.GetComponent<EnemyStats>().speed *= speedMultiplier;
            new_enemy.GetComponent<EnemyHandler>().enemyType = new_enemy_sprite;
            new_enemy.GetComponent<EnemyFollow>().player = player;
            currentEnemies++;
        }
    }

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
