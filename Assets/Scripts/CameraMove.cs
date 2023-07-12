using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public  float journeyLength ;
    public Animator animator;

    public GameObject EndUI;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Update()
    {
        animator.SetTrigger("isEnd");
        startMarker.transform.position = Vector3.Lerp(startMarker.transform.position, endMarker.position, journeyLength * Time.deltaTime);

        if (EndUI.activeSelf)
        {
            Invoke("GameOver", 3f);
        }
    }

    public void AnimationEvent()
    {
        EndUI.SetActive(true);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);
    }
}
