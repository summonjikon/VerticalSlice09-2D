using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    [SerializeField]private Transform parent;
    [Header("Spawn setup")]
    [SerializeField] private FlockUnit flockUnitPrefab;
    [SerializeField] private bool randomizedFlockSize = true;
    [SerializeField] private int randomizedMinimum = 2;
    [SerializeField] private int randomizedMaximum = 10;
    [SerializeField] private int flockSize;
    [SerializeField] private Vector3 spawnBounds;
    [Header("Speed Setup")]
    [Range(0, 10)]
    [SerializeField] private float minSpeed;
    [Range(0, 10)]
    [SerializeField] private float maxSpeed;
    [Header("Detection Distances")]
    [Range(0, 10)]
    [SerializeField] private float _cohesionDistance;
    public float cohesionDistance { get { return _cohesionDistance; } }
    public FlockUnit[] allUnits { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        GenerateUnits();
        if(randomizedFlockSize == true)
        {
            flockSize = Random.Range(randomizedMinimum, randomizedMaximum);
        }
    }
    private void Update()
    {
        for (int i = 0; i < allUnits.Length; i++)
        {
            allUnits[i].MoveUnit();
        }
    }

    private void GenerateUnits()
    {
        allUnits = new FlockUnit[flockSize];
        for (int i = 0; i < flockSize; i++)
        {
            var randomVector = UnityEngine.Random.insideUnitSphere;
            randomVector = new Vector3(randomVector.x * spawnBounds.x, randomVector.y * spawnBounds.y, randomVector.z * spawnBounds.z);
            var spawnPosition = transform.position + randomVector;
            var rotation = Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0);
            allUnits[i] = Instantiate(flockUnitPrefab, spawnPosition, rotation, parent);
            allUnits[i].AssignFlock(this);
            allUnits[i].InitializeSpeed(UnityEngine.Random.Range(minSpeed, maxSpeed));
        }
    }
}