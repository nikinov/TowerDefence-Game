using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IHitable hitable = collision.gameObject.GetComponent<IHitable>();
        if (hitable != null) hitable.Hit(damage);
        Destroy(gameObject);
    }
}
