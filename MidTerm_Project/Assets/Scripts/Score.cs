using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{ 
    public Text MyscoreText;
    private int points;
    void Start()
    {
        MyscoreText.text = " X   " + 0;
    }

    void Update()
    {
        MyscoreText.text = " X   " + Star_PointSystem.ScoreNum;
    }
}
