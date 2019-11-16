using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControler : MonoBehaviour
{
    public float spawnRate;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] Direction dir;

    public bool spawnRateOverTime;

    private float spawnTimer;

    private int cycle = 0;

    private enum Direction
    {
        Left = -1,
        Right = 1
    }

    private void Start()
    {
       // InvokeRepeating("Spawn",0f,spawnRate);
    }

    private void Update()
    {
        if (spawnTimer >= spawnRate)
        {
            Spawn();
            spawnTimer = 0f;
            if (spawnRateOverTime && spawnRate >= 0.1) spawnRate -= Time.deltaTime;
        }

        spawnTimer += Time.deltaTime;
    }

    void Spawn()
    {
        if(cycle < enemy.Length) cycle++;
        int randIndex = Random.Range(0, cycle);
        GameObject en = Instantiate(enemy[randIndex], transform.position, Quaternion.identity);
        en.GetComponent<EnBechaviour>().direaction = (int)dir;
    }
}
