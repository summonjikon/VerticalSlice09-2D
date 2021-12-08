using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyRadius : MonoBehaviour
{
    [SerializeField]private GameObject Player;
    [SerializeField]private float range;
    private float x, xMinus, yMinus, y, xSpeed, ySpeed;
    private Transform start;
    private bool following;
    private float multiplier;
    void Start()
    {
        start = gameObject.transform;
        x = gameObject.transform.position.x + 3;
        y = gameObject.transform.position.y + 3;
        xMinus = gameObject.transform.position.x - 3;
        yMinus = gameObject.transform.position.y - 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(following != true)
        {
            RaycastHit hit;
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 3))
            {
                following = true;
            }
        }
        if(following == true)
        {
            float distance = Vector3.Distance(Player.transform.position, gameObject.transform.position);
            if (gameObject.transform.position.x < x && Player.transform.position.x > gameObject.transform.position.x)
            {
                calculateMultiplier(distance);
                gameObject.transform.position += new Vector3(xSpeed * multiplier * Time.deltaTime, 0, 0);
            }
            else if(gameObject.transform.position.x > xMinus && Player.transform.position.x < gameObject.transform.position.x)
            {
                calculateMultiplier(distance);
                gameObject.transform.position += new Vector3(xSpeed * multiplier * Time.deltaTime, 0, 0);
            }
        }

    }
    private void calculateMultiplier(float distance)
    {
        multiplier = distance /= 3;
    }
}
