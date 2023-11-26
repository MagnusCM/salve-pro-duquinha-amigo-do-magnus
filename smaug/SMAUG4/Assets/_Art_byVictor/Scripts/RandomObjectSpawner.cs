using System.Collections;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // List of objects to spawn

    void Start()
    {
        if (objectsToSpawn.Length == 0)
        {
            Debug.LogError("No objects assigned to spawn. Please assign objects in the Unity Editor.");
        }
        else
        {
            SpawnRandomObject();
        }
    }

    void SpawnRandomObject()
    {
        // Get a random index within the range of the array
        int randomIndex = Random.Range(0, objectsToSpawn.Length);

        // Instantiate the randomly selected object at the spawn point (this GameObject's position)
        GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndex], transform.position, Quaternion.identity);

        // Optionally, you can do something with the spawned object, like modifying its properties or attaching scripts
        // For example, you can set the parent of the spawned object to this GameObject
        spawnedObject.transform.parent = transform;
    }
}
