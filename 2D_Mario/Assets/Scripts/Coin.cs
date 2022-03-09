using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float fLimitTime = 0.5f;
    float fCurrentTime = 0.0f;
    void Start()
    {
        
    }

    private void Update()
    {
        fCurrentTime += Time.deltaTime;

        transform.Translate(Vector2.up * Time.deltaTime * 5.0f);

        if(fLimitTime < fCurrentTime)
        {
            Destroy(gameObject);
        }
    }
}
