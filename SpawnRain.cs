using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRain : MonoBehaviour
{
    [SerializeField] GameObject rainPrefab;
    [SerializeField] GameObject player;

    [SerializeField] float spawnRangeHorizontal = 200f;
    [SerializeField] float spawnRangeVertical = 150f;
    [SerializeField] int collectibleCount;

    void Start()
    {
        InvokeRepeating("SpawnCollectible", 0.5f, 1f);
    }


    void SpawnCollectible()
    {
        GameObject newG = Instantiate(rainPrefab, GenerateSpawnPosition(), rainPrefab.transform.rotation);
        newG.transform.localScale = GenerateSpawnSize();
      
        newG.transform.Rotate(GenerateSpawnRotation(), 3f);
    }

    private Vector3 GenerateSpawnPosition()
    {
        int offsetZ = 1400;

        float spawnPosX = Random.Range(-spawnRangeHorizontal, spawnRangeHorizontal);       
        float spawnPosZ = Random.Range(player.transform.position.z + offsetZ, player.transform.position.z + (offsetZ * 2));

        Vector3 randomPos = new Vector3(spawnPosX, spawnRangeVertical, spawnPosZ);
        return randomPos;
    }

    private Vector3 GenerateSpawnRotation()
    {
        float mazSize = 100;
        float minSize = 50;
        float spawnSize = Random.Range(minSize, mazSize);

        Vector3 randomRot = new Vector3(spawnSize, spawnSize, spawnSize);
        return randomRot;
    }

    private Vector3 GenerateSpawnSize()
    {
        float mazSize = 100;
        float minSize = 50;
        float spawnSize = Random.Range(minSize, mazSize);

        Vector3 randomSize = new Vector3(spawnSize, spawnSize, spawnSize);
        return randomSize;
    }
}
