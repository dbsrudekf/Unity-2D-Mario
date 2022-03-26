using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public bool bIsHammer;
    public float fBulletDir = -1.0f;
    //public float fTempBullet = 0.0f;
    bool bFlipX = false;
    float fSpeed = 2.0f;

    private void Awake()
    {
        bIsHammer = false;
        GameObject BossMonster = GameObject.Find("TurtleBossMonster");
        bFlipX = BossMonster.GetComponent<SpriteRenderer>().flipX;
       
        if (bFlipX)
        {
            fBulletDir = 1.0f;
            //fTempBullet = fBulletDir;
        }
        else
        {
            fBulletDir = -1.0f;
            //fTempBullet = fBulletDir;
        }
    }
    void FixedUpdate()
    {
        if(bIsHammer)
        {
            //fTempBullet = fBulletDir;
            fSpeed = 0.0f;
        }
        else
        {
            //fBulletDir = fTempBullet;
            fSpeed = 2.0f;
        }

        Vector2 dir = new Vector2(fBulletDir, 0);
        transform.Translate(dir * Time.deltaTime * 2.0f * fSpeed);

        if(transform.position.x < -10 || transform.position.x > 37.7f)
        {
            Destroy(gameObject);
        }
    }
}
