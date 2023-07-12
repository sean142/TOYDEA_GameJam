using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstacles;

    private int isAppear, obstacleNumber, randomObstacleATK;
    private Vector3 nextFloor, obstacleSpawnGap, obstacleSpawnPosition;
    private float floorWidth;
    public Vector3[] rotateOffset;
    public Vector3[] positonOffset;

    private void Start()
    {
        floorWidth = 10.0f;
        nextFloor = new Vector3(0.0f, 0.0f, 10.0f);
        obstacleSpawnPosition = new Vector3(0.0f, 0.0f, 9.0f);
        obstacleSpawnGap = new Vector3(0.0f, 0.0f, 6.0f);
    }
    // Update is called once per frame
    void Update()
    {
        if (CheckIfFloorExists(nextFloor))
        {
            while(obstacleSpawnPosition.z < nextFloor.z) 
            {
                spawnObstacle(obstacleSpawnPosition);
                obstacleSpawnPosition += obstacleSpawnGap;
            }
            nextFloor.z += floorWidth;
        }
    }

    bool CheckIfFloorExists(Vector3 position)
    {
        float radius = 0.5f;
        Collider[] colliders = Physics.OverlapSphere(position, radius);
        if (colliders.Length > 0)
        {
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Floor"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    void spawnObstacle(Vector3 position)
    {
        isAppear = Random.Range(0, 2);
        obstacleNumber = Random.Range(0, obstacles.Length);
        if(isAppear == 1)
        {
            Instantiate(obstacles[obstacleNumber], position+positonOffset[obstacleNumber], Quaternion.Euler(rotateOffset[obstacleNumber]));
        }
    }
}
