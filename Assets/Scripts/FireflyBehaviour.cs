using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyBehaviour : MonoBehaviour
{
    private GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(player.transform);

        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.up, distance:100f); ;
        Ray ray;
        if(hit.collider != null)
        {
            Debug.Log("Succes");
        }
    }
}
