using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyRadius : MonoBehaviour
{
    [SerializeField]private GameObject Player;
    [SerializeField]private float range;
    private float x, xMinus, yMinus, y, xSpeed, ySpeed;
    private Transform start;
    [SerializeField]private bool following;
    private float multiplier;
    void Start()
    {
        multiplier = 1;
        start = gameObject.transform;
        x = gameObject.transform.position.x + 3;
        y = gameObject.transform.position.y + 3;
        xMinus = gameObject.transform.position.x - 3;
        yMinus = gameObject.transform.position.y - 3;
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, gameObject.transform.position);
        if(following != true)
        {
            if (distance < 5)
            {
                following = true;
            }
        }
        if(following == true)
        {
            transform.LookAt(Player.transform);
            gameObject.transform.position = transform.forward * multiplier;
        }
    }
    public float calculateMultiplier(float distance)
    {
        multiplier = 1;
        multiplier += distance / 2;
        return multiplier;
    }
}
