using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBridge : MonoBehaviour
{
    float fCurrentTime = 0.0f;
    float fLimitTime = 0.1f;

    int iCount = 0;
    public bool bCol;

    private void Awake()
    {
        bCol = false;
    }

    void Update()
    {
        fCurrentTime += Time.deltaTime;

        if (bCol && fCurrentTime > fLimitTime)
        {
            Debug.Log("Col");
            //StartCoroutine(BridgeDestroy());
            BridgeDestroy();
            fCurrentTime = 0.0f;
        }
    }

    void BridgeDestroy()
    {
        transform.GetChild(iCount).gameObject.SetActive(false);
        iCount++;
        Debug.Log("Coroutine");
    }
}
