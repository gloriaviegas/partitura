using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Move Info")]

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float runSpeed;
    [SerializeField] private float activeSpeed;
    private bool canDoubleJump;

    [Header("Ground Info")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGround;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
       
    }

    // Update is called once per frame
    void Update()

    {
        isGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);


        var xInput = Input.GetAxisRaw("Horizontal");

        activeSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftControl))
             activeSpeed = runSpeed;
        
            

        rb.velocity = new Vector2(xInput * activeSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {

            if (isGround)
            {
                Jump();
                canDoubleJump = true;
                anim.SetBool("isDoubleJumping", false);
            }
            else
            {

                if (canDoubleJump)
                {
                    Jump();
                    canDoubleJump = false;
                    anim.SetBool("isDoubleJumping", true);

                }



            }
        }
        //Configurando direções
        if (rb.velocity.x > 0)
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        if (rb.velocity.x < 0)
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);

        //chamando animações
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGround);
        anim.SetFloat("ySpeed", rb.velocity.y);



    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    }
}
