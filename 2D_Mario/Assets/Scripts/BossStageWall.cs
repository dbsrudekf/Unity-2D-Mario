using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageWall : MonoBehaviour
{
    GameObject Child = null;
    public GameObject prefabs;


    private void Start()
    {
        Child = transform.GetChild(0).gameObject;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && transform.position.y > collision.transform.position.y)
        {
            Child.SetActive(true);

            Vector3 spawnPos = transform.position;
            spawnPos.x = spawnPos.x - 0.1f;
            GameObject instance = Instantiate(prefabs, spawnPos, Quaternion.identity);
        }
    }
}
