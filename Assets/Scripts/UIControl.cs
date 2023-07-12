using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Text ShowScore;
    public GameObject ScoreUI, missUI;
    private void Awake()
    {
        ScoreUI.SetActive(false);
    }

    void Update()
    {
        // Update is called once per frame
        if (!CameraControl.canMove && TreasureATKControl.isStop == 1)
        {
            Debug.Log("TEST");
            ScoreUI.SetActive(true);
            ShowScore.text = TreasureATKControl.leftAttackTime.ToString();
        }
        else
        {
            ScoreUI.SetActive(false);
            
            
        }
        if(TreasureATKControl.isStop == 3)
        {
            missUI.gameObject.SetActive(true);
            Invoke("InvisibleMiss", 0.5f);
            TreasureATKControl.isStop = 0;
        }
    }

    void InvisibleMiss()
    {
        missUI.gameObject.SetActive(false);
    }
}
