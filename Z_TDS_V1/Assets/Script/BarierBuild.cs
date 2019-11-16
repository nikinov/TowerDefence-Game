using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarierBuild : MonoBehaviour,IBuildable
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Collider2D col;

    private Material myMat;

    public void chengMat(Material material)
    {
       // if (sprite.material == material) return;
        sprite.material = material;
    }

    public Bounds getBounds()
    {
        return col.bounds;
    }

    public void OnBuild()
    {
        col.isTrigger = false;
        sprite.material = myMat;
    }

    public void OnSelected()
    {
        col.isTrigger = true;
        myMat = sprite.material;
    }
}
