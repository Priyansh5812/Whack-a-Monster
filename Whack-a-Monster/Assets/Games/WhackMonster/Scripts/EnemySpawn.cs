using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> molePrefabs; // The list of prefabs for the mole characters
    public float spawnInterval = 2f; // The time between mole spawns
    public float minSpawnDelay = 0.5f; // The minimum time before the first mole spawns
    public float maxSpawnDelay = 2f; // The maximum time before the first mole spawns
    public float moleLifetime = 3f; // The amount of time a mole stays on screen before disappearing
    public GameObject XRcamera;

    private List<Transform> spawnPoints = new List<Transform>(); // The list of all possible spawn points
    private float spawnTimer = 0f; // The timer for spawning moles
    private float nextSpawnTime = 0f; // The time when the next mole will spawn

    void Start()
    {
        // Get all the child objects of this game object (i.e., the spawn points)
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child);
        }

        // Set the next spawn time to a random value between minSpawnDelay and maxSpawnDelay
        nextSpawnTime = Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    void Update()
    {
        // Check if it's time to spawn a new mole
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= nextSpawnTime)
        {
            // Reset the timer and set the next spawn time to a random value between minSpawnDelay and maxSpawnDelay
            spawnTimer = 0f;
            nextSpawnTime = Random.Range(minSpawnDelay, maxSpawnDelay);

            // Randomly choose a spawn point for the mole
            Transform spawnPoint = GetRandomSpawnPoint();

            // Check if there is already a mole at the spawn point
            if (!IsMoleAtSpawnPoint(spawnPoint))
            {
                // Randomly choose a mole prefab from the list of prefabs
                int moleIndex = Random.Range(0, molePrefabs.Count);
                GameObject molePrefab = molePrefabs[moleIndex];

                // Spawn a new mole using the chosen prefab at the chosen spawn point
                GameObject mole = Instantiate(molePrefab, spawnPoint.position, Quaternion.identity);
                Debug.Log(mole.GetComponent<Renderer>().material.color);
                mole.transform.LookAt(XRcamera.transform);
                // Destroy the mole after moleLifetime seconds
                Destroy(mole, moleLifetime);
            }
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        // Randomly choose a spawn point from the list of spawn points
        int spawnIndex = Random.Range(0, spawnPoints.Count);
        return spawnPoints[spawnIndex];
    }

    private bool IsMoleAtSpawnPoint(Transform spawnPoint)
    {
        // Check if there is a mole within a small radius of the spawn point
        Collider[] colliders = Physics.OverlapSphere(spawnPoint.position, 0.2f);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Red") || collider.gameObject.CompareTag("Green"));
            {
                return true;
            }
        }

        return false;
    }
}
