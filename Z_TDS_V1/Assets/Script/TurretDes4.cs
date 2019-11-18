using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDes4 : MonoBehaviour
{
    Collision2D col;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        col = coll;
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(25);
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }


    //movement
    int a;
    int b;
    //Save movement
    int c;
    int d;
    //MainMenu
    int coins;
    int Level;
    //MainMenu
    int coins1;
    int Level1;
}
