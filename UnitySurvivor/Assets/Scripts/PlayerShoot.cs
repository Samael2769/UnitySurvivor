using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<GameObject> bulletInfos = new List<GameObject>();
    public float shootDelay = 0.7f;
    public float delta = 0.0f;
    int bulletIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && delta >= shootDelay)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Shoot>().bulletPrefab = bulletInfos[bulletIndex];
            bullet.transform.rotation = Quaternion.LookRotation(getMousePosition());
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * bullet.GetComponent<Shoot>().bulletSpeed;
            delta = 0.0f;
        }
        delta += Time.deltaTime;
    }

    Vector3 getMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0f;
        Vector3 lookPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = lookPosition - transform.position;
        return direction.normalized;
    }

    public void upgradeWeapon()
    {
        if (bulletIndex < bulletInfos.Count - 1)
            bulletIndex++;
    }
}
