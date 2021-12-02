using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]private Camera mainCamera;
    void Start()
    {
        mainCamera = (Camera)FindObjectOfType(typeof(Camera));
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(mainCamera.transform);
    }
}
