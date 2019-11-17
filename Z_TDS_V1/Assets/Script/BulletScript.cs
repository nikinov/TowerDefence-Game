using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IHitable hitable = collision.gameObject.GetComponent<IHitable>();
        if (hitable != null) hitable.Hit(damage);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait ()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    private void Start()
    {
        StartCoroutine(Wait());
    }
}
