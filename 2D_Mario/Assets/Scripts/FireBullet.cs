using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    float fSpeed = 2.0f;
    float fFireBulletDir = 0.0f;
    Rigidbody2D rigid;
    bool bFlipX = false;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameObject player = GameObject.Find("Mario");
        bFlipX = player.GetComponent<SpriteRenderer>().flipX;
        
        if(bFlipX)
        {
            fFireBulletDir = -1.0f;
        }
        else
        {
            fFireBulletDir = 1.0f;
        }
    }
    private void FixedUpdate()
    {

        rigid.velocity = new Vector2(fFireBulletDir * fSpeed, rigid.velocity.y);

    }
}
