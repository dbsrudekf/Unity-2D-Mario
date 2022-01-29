using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomItem : MonoBehaviour
{
    float fSpeed = 5.0f;
    bool bIsPattern = false;
    Vector3 movement;


    Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Create();
 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //movement.Set(0f, 1f, 0f);
        //movement = movement.normalized * 1.0f * Time.deltaTime;
        //rigid.MovePosition(transform.position + movement);
        //if (transform.position.y > -0.7f)
        //{
        //    movement.Set(-1f, 0f, 0f);
        //    movement = movement.normalized * 1.0f * Time.deltaTime;
        //    rigid.MovePosition(transform.position + movement);
        //}
       
        //if (transform.position.y > -0.7f)
        //{
        //    rigid.velocity = new Vector2(-1, 0);
        //}
        //if (transform.position.y < -0.7f)
        //{
        //    rigid.velocity = new Vector2(rigid.velocity.x, 0.5f);
        //    Debug.Log("UP");
        //    bIsPattern = true;
        //}
        
        //if(transform.localPosition.y >= 0.15f)
        //{
        //    rigid.velocity = new Vector2(-1, rigid.velocity.y);
        //}
       
    }

    void Create()
    {
        for(float Itemposition= 1.0f; transform.position.y < -0.7f; Itemposition++)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0.5f);
            Debug.Log("UP");
        }
    }
    void MovePattern()
    {
        
    }
}
