using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDes : MonoBehaviour
{
    Collision2D col;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        col = coll;
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
