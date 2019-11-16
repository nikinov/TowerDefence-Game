using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField]private Transform min, max;
    public GameObject coin;
    public float spawnRate;

    private void Start()
    {
        InvokeRepeating("spawn", spawnRate, spawnRate);
    }

    private void spawn()
    {
        float x = Random.Range(min.position.x, max.position.x);
        float y = Random.Range(min.position.y, max.position.y);
        Vector2 point = new Vector2(x,y);

        Instantiate(coin, point, Quaternion.identity);
    }
}
