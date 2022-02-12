using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomMonster : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    BoxCollider2D col;

    public int nextMove;
    float fTime = 0.0f;
    float fLimitTime = 0.5f;
    bool bIsDeath = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        Invoke("MovePattern", 5);
    }

    private void FixedUpdate()
    {
        
        if (!anim.GetBool("IsDeath"))
        {
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        }
        
        if(anim.GetBool("IsDeath"))
        {
            fTime += Time.deltaTime;
            if (fTime > fLimitTime)
            {
                Destroy(gameObject);
            }
        }
    }

    void MovePattern()
    {
        if(!bIsDeath)
        {
            nextMove = Random.Range(-1, 2);
            Invoke("MovePattern", 5);
        }

    }
    
    public void OnDamaged()
    {
        //Death 애니메이션
        anim.SetBool("IsDeath", true);

        //몇초뒤 사라짐
    }

    public void TurtleDamaged(Vector2 position)
    {
        bIsDeath = true;
        if(position.x > gameObject.transform.position.x)
        {
            nextMove = -1;
        }
        else
        {
            nextMove = 1;
        }
       

        rigid.velocity = new Vector2(nextMove, 2);
        col.isTrigger = true;

        fTime += Time.deltaTime;
        if (fTime > fLimitTime)
        {
            Destroy(gameObject);
        }
        spriteRenderer.flipY = true;

    }

}
