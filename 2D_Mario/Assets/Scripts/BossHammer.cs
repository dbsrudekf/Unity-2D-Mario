using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHammer : MonoBehaviour
{
    GameObject GbossBridge;

    float fCurrentTime = 0.0f;
    float fLimitTime = 0.1f;
    
    int iCount = 0;
    bool bCol;
    private void Awake()
    {
        bCol = false;
        GbossBridge = GameObject.Find("BridgeTileObject");
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GbossBridge.GetComponent<BossBridge>().bCol = true;
            //Destroy(gameObject);
        }
    }

}
