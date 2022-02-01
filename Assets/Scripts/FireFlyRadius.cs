using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyRadius : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]private float range = 3;
    private float y;
    private Vector3 playerPos;
    private Transform start;
    [SerializeField]private bool following;
    private float multiplier;
    void Start()
    {
        multiplier = 2;
        start = gameObject.transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 1, 0);
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (following != true)
        {
            if (distance < range)
            {
                following = true;
            }
        }
        else
        {
            if(distance > 2)
            {
                gameObject.transform.position = Vector3.Lerp(transform.position, playerPos, Time.deltaTime * 1.5f);
            }
            else if (distance > 1)
            {
                gameObject.transform.position = Vector3.Lerp(transform.position, playerPos, Time.deltaTime);
            }
        }
    }
}
