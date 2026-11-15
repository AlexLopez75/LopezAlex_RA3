using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int initialSize = 20;

    private Stack<Bullet> pool = new Stack<Bullet>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        for (int i = 0; i < initialSize; i++)
        {
            pool.Push(CreateBullet());
        }
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform);
        bullet.gameObject.SetActive(false);

        return bullet;
    }

    public Bullet GetBullet(Vector3 position, Quaternion rotation)
    {
        Bullet bullet;

        if (pool.Count > 0)
        {
            bullet = pool.Pop();
        }
        else
        {
            bullet = CreateBullet();
        }
        bullet.transform.SetPositionAndRotation(position, rotation);
        bullet.gameObject.SetActive(true);
        bullet.Init();

        return bullet;
    }

    public void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        pool.Push(bullet);
    }
}
