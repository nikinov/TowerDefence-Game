using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 force;
    [SerializeField] private int magniteForce;
    [SerializeField] private Transform groundChek;
    public float acurancy;

    private Rigidbody2D myRb;
    private int direction;
    private bool canJump;

    private bool APrevDir;
    private bool DPrevDir;

    public bool mob;

    public bool doubleJump;
    private bool dJA;

    [Range(0.02f,0.6f)]public float deadPress;
    private float deadLTimer;
    private float deadRTimer;

    public float movmentA;

    public bool isMagniting { get; private set; }
    public bool isJumping { get; private set; }

    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        dJA = doubleJump;
    }


    private void Update()
    {
        ChekIfGrounded();
        if (!mob)
        {

            bool aKey = Input.GetKey(KeyCode.A);
            bool dKey = Input.GetKey(KeyCode.D);

            float aAxis = Input.GetAxis("JumpL");
            float dAxis = Input.GetAxis("JumpR");

            direction = 0;

            if(aKey && dKey) direction = -3;
            else if (doubleJump && (aKey || dKey))
            {
                
                if (aKey)
                {
                    direction = ((aAxis < movmentA) && APrevDir) ? 0 : -1;
                }
                else if (dKey)
                {
                    direction = ((dAxis < movmentA) && DPrevDir) ? 0 :  1;
                }
            }
            else
            {
                if (aKey)
                {
                    direction = APrevDir ? 0 : -1; ;
                }
                else if (dKey)
                {
                    direction = DPrevDir ? 0 : 1;
                }
            }

            APrevDir = aKey;
            DPrevDir = dKey;

            

            /*
            deadLTimer += (aKey ? 1 : -1) * Time.deltaTime;
            deadRTimer += (dKey ? 1 : -1) * Time.deltaTime;

            if (Mathf.Abs(deadLTimer) >= deadPress)
            {
                APrevDir = aKey;
                deadLTimer = 0f;
            }
            if (Mathf.Abs(deadRTimer) >= deadPress)
            {
                DPrevDir = dKey;
                deadRTimer = 0f;
            }

            if (deadLTimer < 0) deadLTimer = 0;
            if (deadRTimer < 0) deadRTimer = 0;
            */
            //Debug.Log("dLT "+ deadLTimer +" A("+aKey+") prevA("+APrevDir+") dRT D prevD");
        }

    }

    private void FixedUpdate()
    {
        bool jump = ((canJump || dJA) && Mathf.Abs(direction) == 1);
        if (canJump == false && jump == true) dJA = false;

        //Debug.Log("dja " + dJA + " can :" + canJump + " jump: " + jump);

        if (jump) Move();

        if (isJumping && direction == -3) Magnite();
        else isMagniting = false;

        direction = 0;
    }

    private void ChekIfGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundChek.position,Vector2.down,
            acurancy,LayerMask.GetMask("Ground"));

        canJump = (hit && myRb.velocity == Vector2.zero);
        if (canJump && doubleJump) dJA = true;
        isJumping = !canJump;        
    }

    private void Move()
    {
        
        isJumping = true;
        Vector2 dir = Vector2.one;
        dir.x = direction;
        myRb.velocity = force * dir;
        canJump = false;

        
    }
    private void Magnite() {
        Debug.Log("magnet");
        isMagniting = true;
        myRb.velocity += Vector2.down * magniteForce * Time.deltaTime;
        myRb.velocity = Vector2.ClampMagnitude(myRb.velocity, magniteForce);
    }

    public void SetL(bool l)
    {
        //ADir = l;
    }
    public void SetR(bool r)
    {
        //DDir = r;
    }

}
