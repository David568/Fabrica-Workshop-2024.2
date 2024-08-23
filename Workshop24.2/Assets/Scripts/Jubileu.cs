using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jubileu : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    public float inputX;
    public bool inputJump;

    public float speed;
    public float forceJump;

    public bool inGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Inputs();
        JumpLogic();
        Animations();
        Flip();
    }

    private void FixedUpdate()
    {

        MoveLogic();
    }



    public void Inputs()
    {

        inputX = Input.GetAxisRaw("Horizontal");
        inputJump = Input.GetKeyDown(KeyCode.Space);
    }
    public void JumpLogic()
    {

        if(inputJump && inGround)
        {

            rb.velocity = new Vector2(rb.velocity.x, forceJump );
        }
    }
    public void MoveLogic(){

        rb.velocity = new Vector2(inputX *speed , rb.velocity.y);
    }

    public void Flip(){
        if (inputX > 0 ){
            
            sr.flipX = false;
        }else if (inputX < 0){
            
            sr.flipX = true;
        }
    }




    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Ground")){
            inGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Ground")){
            inGround = false;
        }
    }

    public void Animations(){

        anim.SetFloat("Horizontal", rb.velocity.x);
    }
}
