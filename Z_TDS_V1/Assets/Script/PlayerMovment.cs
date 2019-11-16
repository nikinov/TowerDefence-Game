using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovment : MonoBehaviour
{

    public float speed;
    public float maxSpeed;

    private float horAxes;
    private float verAxes;

    private Rigidbody2D myRb;

    private void Start()
    {
        myRb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horAxes = Input.GetAxis("Horizontal");
        verAxes = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {

        Vector2 direction = new Vector2(horAxes, verAxes).normalized;
        myRb.velocity = direction * speed;
    }
}
