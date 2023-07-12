using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    public GameObject player;
    private float backgroundWidth = 17.7f;
    private int backgroundNumber = 3;
    // Start is called before the first frame update

    private void Update()
    {
        if (this.gameObject.transform.position.z + backgroundWidth < player.transform.position.z)
        {
            this.gameObject.transform.position += new Vector3(0.0f, 0.0f, backgroundNumber*backgroundWidth);
        }
    }
}
