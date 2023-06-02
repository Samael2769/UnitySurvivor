using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int score = 0;
    public GameObject scoreHandler;
    // Start is called before the first frame update
    void Start()
    {
        score = scoreHandler.GetComponent<EnemySpawn>().score;
    }

    // Update is called once per frame
    void Update()
    {
        score = scoreHandler.GetComponent<EnemySpawn>().score;
        //TMP text
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score;
    }
}
