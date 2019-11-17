using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour,IHitable
{
    float MyHelth;
    GameManager gameManager;
    public GameObject GaMan;

    private void Awake()
    {
        GaMan = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = GaMan.GetComponent<GameManager>();
        MyHelth = 10;
    }
    private void Update()
    {
        if (MyHelth <= 0)
        {
            Destroy(gameObject);
            gameManager.addMat();
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet1")
        {
            MyHelth -= 1;
        }
        if (col.gameObject.tag == "Bullet2")
        {
            MyHelth -= 3;
        }
        if (col.gameObject.tag == "Bullet3")
        {
            MyHelth -= 5;
        }
        if (col.gameObject.tag == "Bullet4")
        {
            MyHelth -= 14;
        }
        if (col.gameObject.tag == "Bullet5")
        {
            MyHelth -= 30;
        }
        if (col.gameObject.tag == "Bullet6")
        {
            MyHelth -= 50;
        }
        if (col.gameObject.tag == "Trap")
        {
            Destroy(gameObject);
            gameManager.addMat();
        }
    }

    public void Hit(float dam)
    {
        MyHelth -= dam;
        if (MyHelth < 0) Destroy(gameObject);
    }

    public float getHp()
    {
        return MyHelth;
    }
}
