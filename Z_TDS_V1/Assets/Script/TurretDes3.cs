using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDes3 : MonoBehaviour
{
    Collision2D col;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        col = coll;
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(20);
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
