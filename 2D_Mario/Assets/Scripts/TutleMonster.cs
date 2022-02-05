using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutleMonster : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    BoxCollider2D col;

    public int nextMove;
    public int ColliderCount = 0;
    bool bIsDeath = false;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        Invoke("MovePattern", 3);
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
    }
    void MovePattern()
    {
        if(!anim.GetBool("IsDeath"))
        {
            int RandomMove = Random.Range(0, 2);
            switch (RandomMove)
            {
                case 0:
                    nextMove = 1;
                    break;
                case 1:
                    nextMove = -1;
                    break;
            }

            Invoke("MovePattern", 3);
            spriteRenderer.flipX = nextMove == -1; //nextMove가 -1일 때 flipX가 활성화
        }
    }

    void OnAttack()
    {
        if(anim.GetBool("IsAttack"))
        {
            nextMove = 2;
        }
        else
        {
            nextMove = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            nextMove = nextMove * -1;
            spriteRenderer.flipX = nextMove == -1; //nextMove가 -1일 때 flipX가 활성화
        }

        if(bIsDeath)
        {
            if (collision.gameObject.tag == "MonsterTurtle")
            {
                //날아간다.

            }

            if(collision.gameObject.tag == "MonsterMushroom")
            {
                //날아간다.
            }
        }
        
    }

    public void OnDamaged()
    {
        anim.SetBool("IsDeath", true);
        col.size = new Vector2(0.17f, 0.16f);
        nextMove = 0;
        ColliderCount++;
        bIsDeath = true;


        if (ColliderCount != 0 && ColliderCount % 2 == 0)
        {
            anim.SetBool("IsAttack", true);
            OnAttack();
        }
        else
        {
            anim.SetBool("IsAttack", false);
        }
    }
}
