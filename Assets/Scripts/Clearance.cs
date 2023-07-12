using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clearance : MonoBehaviour
{
    void Start()
    {
        DeleteObstacle(this.gameObject.transform.position);
    }
    bool DeleteObstacle(Vector3 position)
    {
        float radius = 5.0f;

        Collider[] colliders = Physics.OverlapSphere(position, radius);

        if (colliders.Length > 0)
        {
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Obstacle"))
                {
                    Destroy(collider.gameObject);
                }
            }
        }
        return false;
    }
}
