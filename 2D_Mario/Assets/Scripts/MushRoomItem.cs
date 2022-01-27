using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomItem : MonoBehaviour
{
    float fSpeed = 5.0f;
    bool bIsPattern = false;
    Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(transform.position.y < -0.7f)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0.5f);
            Debug.Log("UP");
            bIsPattern = true;
        }
        else
        {
            rigid.velocity = new Vector2(-1, rigid.velocity.y);
        }
        
        //if(transform.localPosition.y >= 0.15f)
        //{
        //    rigid.velocity = new Vector2(-1, rigid.velocity.y);
        //}
       
    }
    void MovePattern()
    {
        
    }
}
