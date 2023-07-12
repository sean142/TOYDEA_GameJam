using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObstacle : MonoBehaviour
{
    public static AttackObstacle instance;
    public BoxCollider boxCollider;
    public void Awake()
    {
        instance = this;
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle") )
        {
            Debug.Log("Hit");
            Destroy(other.gameObject);          
        }
    }
}
