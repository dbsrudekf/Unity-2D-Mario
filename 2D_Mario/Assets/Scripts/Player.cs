using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float fSpeed = 5.0f;
    public float jumpPower = 10.0f;

    Rigidbody rRigidbody;
    Vector3 vMovement;
    float fHorizontal;
    SpriteRenderer spriteRenderer;
    Animator anim;


    // Start is called before the first frame update
    void Awake()
    {
        rRigidbody = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        if (Input.GetButtonDown("Jump"))
        {
            rRigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }

        if (Input.GetButtonUp("Horizontal"))
            anim.SetBool("IsWalkingFinish", true);
        else
            anim.SetBool("IsWalkingFinish", false);
        

        if (rRigidbody.velocity.normalized.x == 0)
            anim.SetBool("IsWalking", false);
        else
            anim.SetBool("IsWalking", true);
    }

    void FixedUpdate()
    {
        fHorizontal = Input.GetAxisRaw("Horizontal");
        vMovement.Set(fHorizontal, 0.0f, 0.0f);
        vMovement = vMovement.normalized * fSpeed * Time.deltaTime;
        rRigidbody.MovePosition(transform.position + vMovement);
    }
}
