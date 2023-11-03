using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public GameManager GameManager;

    public GameObject star1, star2, star3;
    public Text StatementText;

    public void show3stars()
    {
        star1.SetActive(true);
        star2.SetActive(true);
        star3.SetActive(true);
    }

    public void show2stars()
    {
        star1.SetActive(true);
        star2.SetActive(true);
        star3.SetActive(false);
    }

    public void show1stars()
    {
        star1.SetActive(true);
        star2.SetActive(false);
        star3.SetActive(false);
    }
}
