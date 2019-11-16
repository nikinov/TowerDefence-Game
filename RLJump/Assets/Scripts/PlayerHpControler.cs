using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpControler : MonoBehaviour
{
    [SerializeField] private Transform groundChek;
    [SerializeField] private float size;
    [SerializeField] private Rigidbody2D rb;

    public GameObject hitEffect;

    public BoxCollider2D hurtBox;

    private bool invincible;

    private IKillListener killListener;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.CompareTag("Enemy"))
        {

            List<Collider2D> hit = new List<Collider2D>(); //= Physics2D.OverlapBoxAll(hurtBox.transform.position, hurtBox.size, 0);
            hurtBox.OverlapCollider(new ContactFilter2D().NoFilter(), hit);
            foreach (Collider2D col in hit)
            {
                if (col.transform.CompareTag("Enemy"))
                {
                    rb.velocity = Vector2.up * 16;
                    invincible = true;
                    Instantiate(hitEffect,hurtBox.transform.position,Quaternion.identity);
                    Destroy(col.gameObject);
                    if (killListener != null) killListener.Kill();
                    return;
                }
            }
            //if(!invincible)
                Destroy(gameObject);
            
        }

        invincible = false;
    }

    public void setListener(IKillListener listener)
    {
        killListener = listener;
    }

}
