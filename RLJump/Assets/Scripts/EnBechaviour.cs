using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnBechaviour : MonoBehaviour
{

    public int constSpeed;
    public int direaction;
    private Rigidbody2D myRb;

    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        myRb.velocity = Vector2.right * direaction * constSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("DieArea"))
        {
            Destroy(gameObject);
        }
    }

}
