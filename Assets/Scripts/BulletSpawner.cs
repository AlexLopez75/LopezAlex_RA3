using System;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float bulletSpeed = 5f;

    private float spawnTimer;


    private void Start()
    {
        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
        {
            return;
        }

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            BulletSpawn();
            spawnTimer = spawnInterval;
        }
    }


    public void BulletSpawn()
    {
        Bullet bullet = BulletPool.Instance.GetBullet(firePoint.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = firePoint.up * bulletSpeed;
        Debug.Log(bullet);
    }
}
