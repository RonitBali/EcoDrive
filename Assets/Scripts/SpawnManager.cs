using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject trashPrefab;       // Prefab of the trash collectible
    public Transform[] spawnPoints;      // Array of spawn points
    public float spawnInterval = 5f;     // Time interval between spawns

    private GameObject[] currentTrashObjects; // Array to track spawned trash objects

    private void Start()
    {
        // Initialize the array to track the spawn state at each spawn point
        currentTrashObjects = new GameObject[spawnPoints.Length];

        // Start spawning trash collectibles at regular intervals
        InvokeRepeating(nameof(SpawnTrash), spawnInterval, spawnInterval);
    }

    private void SpawnTrash()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned in Spawn Manager!");
            return;
        }

        // Loop through each spawn point and check if trash is already spawned
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (currentTrashObjects[i] == null) // Check if there's no trash at this spawn point
            {
                // Instantiate the trash at the current spawn point
                currentTrashObjects[i] = Instantiate(trashPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
                break; // Exit after spawning one object
            }
        }
    }
}
