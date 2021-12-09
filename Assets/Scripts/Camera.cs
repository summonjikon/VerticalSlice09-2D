using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [Range(0, 10)]
    public float smoothFactor;
    public Vector3 minPos, maxPos;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 playerPosition = player.position + offset;

        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(playerPosition.x, minPos.x, maxPos.x),
            Mathf.Clamp(playerPosition.y, minPos.y, maxPos.y),
            Mathf.Clamp(playerPosition.z, minPos.z, maxPos.z));

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
