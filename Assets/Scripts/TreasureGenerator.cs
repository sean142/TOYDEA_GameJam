using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TreasureGenerator : MonoBehaviour
{
    public GameObject treasurePrefab;
    public float interval;
    private Vector3 spawnOffset = new Vector3(0.0f, 1.0f, 10.0f);
    private void Start()
    {
        StartCoroutine(LogRoutine());
    }
    private System.Collections.IEnumerator LogRoutine()
    {
        //int repeatCount = Mathf.FloorToInt(30 / interval);
        int repeatCount = 3;
        for (int i = 0; i < repeatCount; i++)
        {
            yield return new WaitForSeconds(interval);
            SpawnTreasureBox();
        }
    }

    private void SpawnTreasureBox()
    {
        Vector3 spawnPos = this.transform.position + spawnOffset;
        Debug.Log("spawn at " + spawnPos);
        GameObject temp = Instantiate(treasurePrefab, spawnPos, Quaternion.identity);
        temp.transform.rotation = Quaternion.Euler(0f, 135f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
            Debug.Log("Destroy");
        }
    }
}
