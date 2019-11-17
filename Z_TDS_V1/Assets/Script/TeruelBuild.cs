using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeruelBuild : MonoBehaviour,IBuildable
{

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Collider2D col;
    [SerializeField] private SpriteRenderer headsSprite;
    [SerializeField] private TeruelShooting shooting;
    [SerializeField] private TeruelTargetFinder finder;

    private Material myMat;

    public void chengMat(Material material)
    {
        sprite.material = material;
        headsSprite.material = material;
    }

    public Bounds getBounds()
    {
        return col.bounds;
    }

    public void OnBuild()
    {
        col.isTrigger = false;
        headsSprite.material = myMat;
        sprite.material = myMat;
        shooting.enabled = true;
        finder.enabled = true;
    }

    public void OnSelected()
    {
        col.isTrigger = true;
        myMat = sprite.material;
        shooting.enabled = false;
        finder.enabled = false;
    }
}
