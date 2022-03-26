using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHammer : MonoBehaviour
{
    GameObject GbossBridge;
    GameObject GbossMonster;
    public GameObject GbossBullet;
    SpriteRenderer spriteRender;

    float fCurrentTime = 0.0f;
    float fLimitTime = 0.1f;
    
    int iCount = 0;
    bool bCol;
    private void Awake()
    {
        bCol = false;
        GbossBridge = GameObject.Find("BridgeTileObject");
        GbossMonster = GameObject.Find("TurtleBossMonster");
        
        spriteRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GbossBridge.GetComponent<BossBridge>().bCol = true;
            GbossMonster.GetComponent<BossMonster>().bIsHammer = true;
            GbossMonster.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GbossBullet.GetComponent<BossBullet>().bIsHammer = true;
            Debug.Log(GbossBullet.GetComponent<BossBullet>().bIsHammer);
            spriteRender.enabled = false;

        }
    }

}
