using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifing : MonoBehaviour
{
    public int health = 100;
    public GameObject lifeHandler;
    // Start is called before the first frame update
    void Start()
    {
        health = lifeHandler.GetComponent<Movement>().health;
    }

    // Update is called once per frame
    void Update()
    {
        //Image fill
        health = lifeHandler.GetComponent<Movement>().health;
        gameObject.GetComponent<UnityEngine.UI.Image>().fillAmount = (float)health / 100;
    }
}
