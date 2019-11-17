using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TeruelShooting))]
public class TeruelTargetFinder : MonoBehaviour
{
    TeruelShooting shooting;

    public float rangeRadius;
    public LayerMask enemyMask;
    public LayerMask obsticleMasks;

    void Start()
    {
        shooting = gameObject.GetComponent<TeruelShooting>();
    }

    private void Update()
    {
        Transform tg = shooting.GetTarget();
        if (tg == null || Vector2.Distance(transform.position, tg.position) > rangeRadius) searchForEnemies();
    }

    private void searchForEnemies()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, rangeRadius,enemyMask);

        Transform closest = null;
        float minDist = rangeRadius;

        foreach(Collider2D collider in col){

            IHitable hitable = collider.gameObject.GetComponent<IHitable>();
            if(hitable != null)
            {
                float dst = Vector2.Distance(collider.transform.position, transform.position);
                if(minDist > dst)
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position,(collider.transform.position - transform.position).normalized, dst, obsticleMasks);
                    if (hit)
                    {
                        Debug.Log("hit");
                        if (hit.collider != collider) {
                            Debug.Log(hit.collider.name);
                            continue;
                        }
                    }
                    minDist = dst;
                    closest = collider.transform;
                }
            }

        }

        shooting.SetTarget(closest);

    }

}
