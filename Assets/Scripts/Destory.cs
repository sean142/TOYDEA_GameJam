using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
    private GameObject player;
    private float deleteThreshold = 3.0f;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.z < player.transform.position.z - deleteThreshold)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Treasure")
        {
            Destroy(this.gameObject);
            Debug.Log("Destroy");
        }
    }

}
