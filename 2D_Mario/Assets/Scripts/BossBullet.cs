using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    float fBulletDir = -1.0f;
    bool bFlipX = false;
    private void Start()
    {
        //GameObject BossMonster = GameObject.Find("BossMonster");
        //bFlipX = BossMonster.GetComponent<SpriteRenderer>().flipX;
        //
        //if (bFlipX)
        //{
        //    fBulletDir = -1.0f;
        //}
        //else
        //{
        //    fBulletDir = 1.0f;
        //}
    }
    private void Update()
    {
        Vector2 dir = new Vector2(fBulletDir, 0);
        transform.Translate(dir * Time.deltaTime * 2.0f);
    }
}
