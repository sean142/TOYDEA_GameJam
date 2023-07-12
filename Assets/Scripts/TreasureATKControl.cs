using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreasureATKControl : MonoBehaviour
{
    private GameObject player;
    private float distance, distanceThreshold = 3.0f, countdown = 2.0f;
    private int atkThreshold;

    public static int isStop = 0;
    public static int leftAttackTime;


    void Start()
    {
        isStop = 0;
        player = GameObject.Find("Player");
        atkThreshold = Random.Range(7, 16);
        leftAttackTime = atkThreshold;
        Debug.Log("ATK" + atkThreshold);
    }

    void Update()
    {
        distance = this.transform.position.z - player.transform.position.z;

        if (distance < distanceThreshold && isStop == 0)
        {
            // UI set active
            // 剩下需要攻擊的次數 用"leftAttackTime"存著
            isStop = 1;
            CameraControl.canMove = false;
            Invoke("MissTreasure", countdown);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (isStop == 1)
            {
                leftAttackTime--;
            }
            if(leftAttackTime == 0)
            {
                GetTreasure();
            }
        }
    }

    private void GetTreasure()
    {
        Debug.Log("Get treasure");
        HeartControl.currentLife++;
        AudioManager.instance.TreasureAudio();
        isStop = 2;
        CameraControl.canMove = true;
        this.gameObject.SetActive(false);
    }
    void MissTreasure()
    {
        if(isStop != 2)
        {
            Debug.Log("Miss");
            isStop = 3;
        }
        CameraControl.canMove = true;
        this.gameObject.SetActive(false);
    }
}
