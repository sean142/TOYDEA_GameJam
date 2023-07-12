using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FloorControl : MonoBehaviour
{
    public GameObject player;
    
    private int floorNumber;
    private float floorWidth, moveThreshold;

    private void Start()
    {
        floorWidth = 10.0f;
        floorNumber = 4;
        moveThreshold = -15.0f;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log(player.transform.position);
        }
        if(this.gameObject.transform.position.z - player.transform.position.z < moveThreshold)
        {
            //Debug.Log(player.transform.position.z);
            this.gameObject.transform.position += new Vector3(0.0f, 0.0f, floorWidth * floorNumber);
        }
    }
}
