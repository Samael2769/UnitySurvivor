using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float timeDelay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3(0, 0, -10);
        transform.position = player.transform.position + new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = player.transform.position + new Vector3(0, 0, -10);
        // transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, 0, -10), timeDelay);
        transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, 0, -10), timeDelay * Time.deltaTime);
    }
}
