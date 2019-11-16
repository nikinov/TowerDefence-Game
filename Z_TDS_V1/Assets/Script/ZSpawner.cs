using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
[RequireComponent(typeof(BoxCollider2D))]
public class ZSpawner : MonoBehaviour
{
    public float spawnRate;

    public bool Go;

    [SerializeField] private GameObject zombieIns;
    [SerializeField] private Transform targetTransform;

    private Bounds bounds;

    private void Start()
    {
        Go = false;
        bounds = gameObject.GetComponent<BoxCollider2D>().bounds;
        if (Go == true)
        {
            InvokeRepeating("Spawn", 1f, spawnRate);
        }
    }

    public void Spawn()
    {
        GameObject en = Instantiate(zombieIns,randPos(),Quaternion.identity) as GameObject;
        en.GetComponent<AIDestinationSetter>().target = targetTransform;
    }

    private Vector2 randPos()
    {
        bool randY = Random.Range(0, 2) == 1;
        bool minY = Random.Range(0, 2) == 1;
        bool minX = Random.Range(0, 2) == 1;

        float y = randY ? Random.Range(bounds.min.y, bounds.max.y) : (minY ? bounds.min.y : bounds.max.y);
        float x = randY ? (minY ? bounds.min.x : bounds.max.x) : Random.Range(bounds.min.x, bounds.max.x);

        return new Vector2(x, y);
    }
}
