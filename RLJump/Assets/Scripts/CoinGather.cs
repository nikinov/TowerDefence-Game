using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGather : MonoBehaviour
{

    public IScoreAdder score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            if (score != null) score.addScore(5);
            Destroy(collision.gameObject);
        }
    }
}
