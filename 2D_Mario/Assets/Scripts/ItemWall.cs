using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWall : MonoBehaviour
{
    public GameObject[] prefabs;

    Animator anim;

    bool bItemOn = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && bItemOn)
        {
            bItemOn = false;
            
            anim.SetBool("IsItemOff", true);

            int iselection = Random.Range(0, prefabs.Length);

            iselection = 0;
            GameObject selectedPrefab = prefabs[iselection];

            Vector3 spawnPos = transform.position;

            GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
            //instance.transform.parent = gameObject.transform;

        }
    }
}
