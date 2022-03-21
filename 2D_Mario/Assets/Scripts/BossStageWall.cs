using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageWall : MonoBehaviour
{
    GameObject Child = null;
    public GameManager gameManager;
    public GameObject prefabs;

    bool bCol = false;

    private void Start()
    {
        Child = transform.GetChild(0).gameObject;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!bCol)
        {
            if (collision.gameObject.tag == "Player" && transform.position.y > collision.transform.position.y)
            {
                Child.SetActive(true);

                Vector3 spawnPos = transform.position;
                spawnPos.x = spawnPos.x - 0.1f;
                GameObject instance = Instantiate(prefabs, spawnPos, Quaternion.identity);
                gameManager.StageScore += 200;
                gameManager.StageCoin += 1;
                bCol = true;
            }
        }
        
    }
}
