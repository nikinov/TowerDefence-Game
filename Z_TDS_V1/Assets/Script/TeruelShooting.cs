using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeruelShooting : MonoBehaviour
{
    private Transform target;

    [SerializeField] private GameObject bulletInst;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float fireRate;

    private float fireTimer;

    private void Update()
    {
        if (target != null)
        {
            fireTimer += Time.deltaTime;

            if(fireTimer >= fireRate)
            {
                Shoot();
                fireTimer = 0f;
            }
        }
    }

    private void Shoot()
    {
        GameObject gameObj = Instantiate(bulletInst, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = gameObj.GetComponent<Rigidbody2D>();

        Vector2 direction = (target.position - firePoint.position).normalized;
        bulletRb.velocity = direction * 10;
    }

    public void SetTarget(Transform transform)
    {
        target = transform;
    }
    public Transform GetTarget()
    {
        return target;
    }
}
