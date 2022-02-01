using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomItem : MonoBehaviour
{
    float fSpeed = 5.0f;
    float fTime = 0.0f;
    float fLimitTime = 2.0f;

    bool bIsPattern = false;
    Vector3 movement;


    Rigidbody2D rigid;
    BoxCollider2D collider;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        fTime += Time.deltaTime;
        if(fTime < fLimitTime)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0.5f);
            
        }
        else
        {
            collider.isTrigger = false;
        }
    }
    void MovePattern()
    {
        
    }
}
