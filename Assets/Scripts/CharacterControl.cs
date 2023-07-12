using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour
{
    public GameObject gameOverScene;

    private Animator animator;
    public bool isDead;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!isDead)
        {
            animator.SetBool("isAttack", true);
            AttackObstacle.instance.boxCollider.enabled = true;
            AudioManager.instance.AttackAudio();
            Invoke("EndingAttack", 0.5f);
        }
        if(HeartControl.currentLife == 0)
        {
            isDead = true;
            Debug.Log("Dead!");
            Invoke("GameOver", 1);
            Transform objectTransform = gameObject.transform;
            objectTransform.localScale = new Vector3(1, 1, 0.1f);
            CameraControl.canMove = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Obstacle"))
       {
            HeartControl.currentLife--;
            AudioManager.instance.HurtAudio();
       }
    }
    private void GameOver()
    {
        gameOverScene.SetActive(true);
        Invoke("ChangeScene", 1f);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

    }
    public void EndingAttack()
    {
        animator.SetBool("isAttack", false);
        AttackObstacle.instance.boxCollider.enabled = false;

    }
}
