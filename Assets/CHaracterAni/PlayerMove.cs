using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;
    public float speed = 3f;
    private bool jump = false;
    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        float hpos = Input.GetAxisRaw("Horizontal");//hpos:Horizontal Position
        Vector3 currentPos = transform.position;//currentPos:current Position
        if (hpos > 0)
        { 
            //going to the right side
            currentPos.x += speed * Time.deltaTime;
            sr.flipX = false;

            anim.SetBool("walk", true);
            anim.SetBool("jump", false);
        }
        else if (hpos < 0)
        {
            currentPos.x -= speed * Time.deltaTime;
            sr.flipX = true;

            anim.SetBool("walk", true);
            anim.SetBool("jump", false);
        }
        else if (hpos == 0)
        {
            anim.SetBool("walk", false);
            anim.SetBool("jump", false);
        }
        transform.position = currentPos;
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jump == true)
        {
            anim.SetBool("idle", false);
            anim.SetBool("walk", false);
            anim.SetBool("jump", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            jump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            jump = false;
        }
    }
}
