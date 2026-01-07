using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAcceleratingSpawner : MonoBehaviour
{
    public Transform storage;
    [Header("Prefabs")]
    public GameObject[] prefabs;

    [Header("Spawn Points (5)")]
    public Transform[] spawnPoints;

    [Header("Spawn Timing")]
    public float startInterval = 2f;
    public float minInterval = 0.3f;
    public float acceleration = 0.05f; // насколько уменьшается интервал

    private float currentInterval;
    private Coroutine spawnRoutine;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void OnEnable()
    {
        currentInterval = startInterval;
        spawnRoutine = StartCoroutine(SpawnLoop());
    }

    private void OnDisable()
    {
        if (spawnRoutine != null)
            StopCoroutine(spawnRoutine);

        ClearSpawned();
    }

    // --------------------
    // SPAWN LOOP
    // --------------------

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(currentInterval);

            // ускоряем спавн
            currentInterval = Mathf.Max(minInterval, currentInterval - acceleration);
        }
    }

    void Spawn()
    {
        if (prefabs.Length == 0 || spawnPoints.Length == 0)
            return;

        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject obj = Instantiate(prefab, point.position, point.rotation,storage.transform);
        spawnedObjects.Add(obj);
    }

    // --------------------
    // CLEAR
    // --------------------

    void ClearSpawned()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
                Destroy(obj);
        }

        spawnedObjects.Clear();
    }
}
