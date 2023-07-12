using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraControl : MonoBehaviour
{
    public float cameraSpeed;
    //public float maxCameraSpeed;

    public static bool canMove;

    public float addCameraSpeed;
    public float increaseInterval;
    private float timer;
    //public Volume volume;

    //public MotionBlur motionBlur;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        timer = 0.0f;
        //volume = FindObjectOfType<Volume>();

        ///volume.profile.TryGet(out motionBlur);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            timer += Time.deltaTime;
            if (timer >= increaseInterval)
            {
                cameraSpeed += addCameraSpeed;
                timer = 0.0f;
            }
            /*
            if (cameraSpeed >= maxCameraSpeed)
            {
                //motionBlur.intensity.value = 1f;
                Debug.LogError("Speed");
            }*/

            this.transform.Translate(cameraSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
    }

    
}
