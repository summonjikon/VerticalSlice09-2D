using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPatern : MonoBehaviour
{
    [SerializeField] private float maxVelocity = 0.1f;
    [SerializeField] private float maxMinusVelocity = -0.1f;
    private float startX, startY, velocityY, velocityX;
    private float multiplier = 1f;
    private Rigidbody2D body;
    [SerializeField]private GameObject Firefly;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        startX = Firefly.transform.position.x;
        startY = Firefly.transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(velocityX * Time.deltaTime, velocityY * Time.deltaTime, 0);
        if(gameObject.transform.position.x > startX)
        {
            if(velocityX < 0)
            {
                CalculateMultiplier(velocityX);
                velocityX += Time.deltaTime * multiplier;
            }
            else
            {
                velocityX += Time.deltaTime;
            }
        } // deze
        else
        {
            if(velocityX > 0)
            {
                CalculateMultiplier(velocityX);
                velocityX -= Time.deltaTime * multiplier;
            }
            else
            {
                velocityX -= Time.deltaTime;
            }
        }
        if(gameObject.transform.position.y > startY)
        {
            if(velocityY < 0)
            {
                CalculateMultiplier(velocityY);
                velocityY += Time.deltaTime * multiplier;
            }
            else
            {
                velocityY += Time.deltaTime;
            }
        } // deze
        else
        {
            if(velocityY > 0)
            {
                CalculateMultiplier(velocityY);
                velocityY -= Time.deltaTime * multiplier;
            }
            else
            {
                velocityY -= Time.deltaTime;
            }
        }
    }
    public void CalculateMultiplier(float speed)
    {
        multiplier = System.Math.Abs(speed / 4);
        multiplier++;
    }
    public void randomDirection()
    {

    }
}
