using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomMonster : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public int nextMove;
    float fTime = 0.0f;
    float fLimitTime = 0.5f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
        nextMove = Random.Range(-1, 2);

        Invoke("MovePattern", 5);
    }
    
    public void OnDamaged()
    {
        //Death 애니메이션
        anim.SetBool("IsDeath", true);

        Debug.Log("OnDamaged");
        //몇초뒤 사라짐
    }
}
