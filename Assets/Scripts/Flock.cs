using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    [SerializeField] private GameObject flockUnitPrefab;
    [SerializeField] private int flockSize;
    [SerializeField] private Vector2 spawnBounds;

    public GameObject[] allUnits { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        GenerateUnits();
    }

    private void GenerateUnits()
    {
        allUnits = new GameObject[flockSize];
        for ( int i = 0; i < flockSize; i++)
        {
            var randomVector = UnityEngine.Random.insideUnitCircle;
            randomVector = new Vector2(randomVector.x * spawnBounds.x, randomVector.y * spawnBounds.y);
            var spawnPosition = new Vector2(transform.position.x, transform.position.y) + randomVector;
            var rotation = Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0);
            allUnits[i] = Instantiate(flockUnitPrefab, spawnPosition, rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
