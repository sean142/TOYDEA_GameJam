using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartControl : MonoBehaviour
{
    public GameObject[] redHeart, grayHeart;
    public float decreaseInterval = 10.0f;
    public static int currentLife;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        currentLife = 3;
        for(int i = 0;i < 3;i++) 
        { 
            Invoke("HeartDecreaseByTime", decreaseInterval*(i+1));
        }
    }

    private void Update()
    {
        HeartUIControl();
        if (currentLife == 0)
        {
            Debug.Log("Game Over");
        }

    }
    // Update is called once per frame
    void HeartDecreaseByTime()
    {
        currentLife--;
    }

    void HeartUIControl()
    {
        for (int i = 0; i < currentLife; i++)
        {
            redHeart[i].SetActive(true);
            grayHeart[i].SetActive(false);
        }
        for(int j = currentLife; j < 3; j++)
        {
            redHeart[j].SetActive(false);
            grayHeart[j].SetActive(true);
        }
    }
}
