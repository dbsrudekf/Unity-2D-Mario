using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int TotalScore = 0;
    public int StageScore = 0;
    public int TotalCoin = 0;
    public int StageCoin = 0;
    public int StageIndex = 1;
    public int SubStageIndex = 1;

    public Text UIScore;
    public Text UICoin;

    private void Update()
    {
        UIScore.text = (TotalScore + StageScore).ToString();
        UICoin.text = (TotalCoin + StageCoin).ToString();
    }
}
