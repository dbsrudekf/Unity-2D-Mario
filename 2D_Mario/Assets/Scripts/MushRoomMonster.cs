using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomMonster : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("MovePattern", 5);
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
    }

    void MovePattern()
    {
        nextMove = Random.Range(-1, 2);

        Invoke("MovePattern", 5);
    }
}
