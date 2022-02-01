using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float fSpeed = 5.0f;
    public float jumpPower = 10.0f;

    Rigidbody2D rRigidbody;
    float fHorizontal;
    SpriteRenderer spriteRenderer;
    Animator anim;
    BoxCollider2D collider;


    // Start is called before the first frame update
    void Awake()
    {
        rRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Horizontal"))
        {
            rRigidbody.velocity = new Vector2(rRigidbody.velocity.normalized.x * 0.5f, rRigidbody.velocity.y);
        }

        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        if (Input.GetButtonDown("Jump") && !anim.GetBool("IsJumping"))
        {
            rRigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
            anim.SetBool("IsWalkingFinish", false);
        }

        if (Input.GetButtonUp("Horizontal"))
            anim.SetBool("IsWalkingFinish", true);
        else
            anim.SetBool("IsWalkingFinish", false);
        

        if (Mathf.Abs(rRigidbody.velocity.x) < 0.3)
        {
            //spriteRenderer.sprite.name = "UpgradeMario2";
            anim.SetBool("IsBigWalking", false);
            anim.SetBool("IsWalking", false);
        }
        else
        {
            if(anim.GetBool("IsMushroomItem"))
            {
                anim.SetBool("IsBigWalking", true);
            }
            else
            {
                anim.SetBool("IsWalking", true);
            }
        }

    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rRigidbody.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rRigidbody.velocity.x > fSpeed)
            rRigidbody.velocity = new Vector2(fSpeed, rRigidbody.velocity.y);
        else if(rRigidbody.velocity.x < fSpeed * (-1))
            rRigidbody.velocity = new Vector2(fSpeed * (-1), rRigidbody.velocity.y);

        if(rRigidbody.velocity.y < 0)
        {
            Debug.DrawRay(rRigidbody.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rRigidbody.position, Vector3.down, 1, LayerMask.GetMask("Floor"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                    anim.SetBool("IsJumping", false);
            }
        }

        if (spriteRenderer.sprite.name == "UpgradeMario")
        {
            collider.size = new Vector2(0.16f, 0.16f);
        }
        if (spriteRenderer.sprite.name == "UpgradeMario1")
        {
            collider.size = new Vector2(0.16f, 0.33f);
        }
        if (spriteRenderer.sprite.name == "UpgradeMario2")
        {
            collider.size = new Vector2(0.16f, 0.33f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "MushRoomItem")
        {
            anim.SetBool("IsMushroomItem", true);   
            Destroy(collision.gameObject);
        }
    }
}
