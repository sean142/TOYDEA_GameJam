using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeInterval;
    public Vector3 dragonPositionOffset, dragonRotateOffset;
    private Vector3 position;
    public GameObject dragon;
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        Invoke("Ending", timeInterval);
    }


    // Update is called once per frame
    void Ending()
    {

        Instantiate(dragon, player.transform.position + dragonPositionOffset, transform.rotation * Quaternion.Euler(dragonRotateOffset));
        Invoke("PlayEndingAnimation", 2);
        Debug.Log("WIN");
    }
    void PlayEndingAnimation()
    {
        
    }
}
