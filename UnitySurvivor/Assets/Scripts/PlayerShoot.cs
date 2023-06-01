using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<GameObject> bulletInfos = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Shoot>().bulletPrefab = bulletInfos[0];
            bullet.transform.rotation = Quaternion.LookRotation(getMousePosition());
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * bullet.GetComponent<Shoot>().bulletSpeed;
        }
    }

    Vector3 getMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0f;
        Vector3 lookPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = lookPosition - transform.position;
        return direction.normalized;
    }
}
