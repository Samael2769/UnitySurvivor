using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = bulletPrefab.GetComponent<ShootInfo>().speed;
        bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bullet.transform.rotation = transform.rotation;
        bullet.transform.rotation = Quaternion.Euler(0, 0, getZRotationWithMousePosition());
        bullet.transform.parent = this.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bullet == null)
        {
            Destroy(this.gameObject);
        }
    }

    float getZRotationWithMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0f;
        Vector3 lookPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = lookPosition - transform.position;
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
}
