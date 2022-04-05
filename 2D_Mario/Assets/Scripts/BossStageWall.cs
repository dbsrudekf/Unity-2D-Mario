using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageWall : MonoBehaviour
{
    GameObject Child = null;
    public GameObject prefabs;

    public GameObject ScoreUIPos;
    public GameObject prefabScoreUI;
    GameObject canvas;
    GameObject ScoreUI;
    float fScoreUIxPos = 70.0f;
    float fScoreUILimitTime = 0.5f;
    bool bIsScoreUI = true;

    float fTime = 0.0f;

    bool bCol = false;

    private void Start()
    {
        Child = transform.GetChild(0).gameObject;
        canvas = GameObject.Find("Canvas");
    }

    private void FixedUpdate()
    {
        if (!bIsScoreUI)
        {
            //ScoreUI = Instantiate(prefabScoreUI, canvas.transform).GetComponent<RectTransform>();
            ScoreUI = Instantiate(prefabScoreUI, canvas.transform);

            Vector2 _ScoreUIPos = Camera.main.WorldToScreenPoint(ScoreUIPos.transform.position);

            _ScoreUIPos.x = _ScoreUIPos.x + fScoreUIxPos;

            ScoreUI.transform.position = _ScoreUIPos;

            bIsScoreUI = true;
        }

        if (ScoreUI)
        {
            fTime += Time.deltaTime;
            ScoreUI.transform.Translate(new Vector2(0, 0.5f));
        }

        if (fTime > fScoreUILimitTime)
        {
            Destroy(ScoreUI);
        }
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
                GameManager.Instance.StageScore += 200;
                GameManager.Instance.StageCoin += 1;
                bCol = true;
                bIsScoreUI = false;
            }
        }
        
    }
}
