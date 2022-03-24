using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : MonoBehaviour
{
    Rigidbody2D rigid;
    BoxCollider2D col;
    SpriteRenderer spriteRenderer;
    public GameObject BulletPrefab;
    public Transform tBulletPos;
    public Transform tBulletBackPos;
    GameObject player;

    public int nextMove;
    public bool bIsHammer = false;
    float fJumpPower = 6.0f;
    float fBossDeathHeight;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Mario");
        nextMove = -1;
        fBossDeathHeight = -4.0f;
        Invoke("BulletCreate", 2.2f);
    }

    private void FixedUpdate()
    {
        if(transform.position.y < fBossDeathHeight)
        {
            Destroy(gameObject);
        }

        if(player.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
            //nextMove = 1;
        }
        else
        {
            spriteRenderer.flipX = false;
            //nextMove = -1;
        }
        
        if(bIsHammer)
        {
            nextMove = 0;
            fJumpPower = 0;
            
        }
        else
        {
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bridge")
        {
            rigid.AddForce(Vector2.up * fJumpPower, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FrontBossLine")
        {
            nextMove = 1;
        }
        
        if (collision.gameObject.tag == "BackBossLine")
        {
            nextMove = -1;
        }
    }

    void BulletCreate()
    {
        if(!spriteRenderer.flipX)
        {
            GameObject instance = Instantiate(BulletPrefab, tBulletPos.position, Quaternion.identity);
        }
        else
        {
            GameObject instance = Instantiate(BulletPrefab, tBulletBackPos.position, Quaternion.identity);
        }
        
        Invoke("BulletCreate", 2.2f);

    }
}
