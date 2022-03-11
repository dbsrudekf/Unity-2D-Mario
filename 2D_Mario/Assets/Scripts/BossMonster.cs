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

    public int nextMove;
    float fJumpPower = 6.0f;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("MovePattern", 2);
        //Invoke("BulletCreate", 2);
    }

    private void FixedUpdate()
    {
        Vector2 rayPos = rigid.position;

        rayPos.x = rigid.position.x - 1;

        Debug.DrawRay(rayPos, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(rayPos, Vector3.down, 1, LayerMask.GetMask("BossMoveLine"));

        if (rayHit.collider != null)
        {
            nextMove = 1;
        }

        if (nextMove == 1)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bridge")
        {
            rigid.AddForce(Vector2.up * fJumpPower, ForceMode2D.Impulse);
        }
    }
    void MovePattern()
    {
        nextMove = Random.Range(-1, 2);

        Invoke("MovePattern", 2);
    }

    void BulletCreate()
    {
        if(!spriteRenderer.flipX)
        {
            GameObject instance = Instantiate(BulletPrefab, tBulletPos.position, Quaternion.identity);  
        }
        Invoke("BulletCreate", 2);

    }
}
