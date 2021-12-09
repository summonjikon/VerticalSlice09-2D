using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            waitTime = 0.1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if(waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.1f;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0;
        }
    }
}
