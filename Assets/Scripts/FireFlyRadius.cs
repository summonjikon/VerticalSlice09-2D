using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyRadius : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]private float range;
    private float y;
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
        y = player.transform.position.y + 1;
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
            if(distance > 1)
            {
                gameObject.transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime);
            }
        }
    }
}
