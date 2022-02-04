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
            spriteRenderer.flipX = nextMove == -1;
        }
    }

    void OnAttack()
    {
        if(anim.GetBool("IsAttack"))
        {
            nextMove = 1;
        }
        else
        {
            nextMove = 0;
        }
        Invoke("OnAttack", 3);
    }

    public void OnDamaged()
    {
        anim.SetBool("IsDeath", true);
        col.size = new Vector2(0.17f, 0.16f);
        nextMove = 0;
        ColliderCount++;
        
        if(ColliderCount != 0 && ColliderCount % 2 == 0)
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
