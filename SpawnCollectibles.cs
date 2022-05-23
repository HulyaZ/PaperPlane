using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectibles : MonoBehaviour
{
    [SerializeField] GameObject collectiblePrefab;
    [SerializeField] GameObject powerUpPrefab;

    [SerializeField] float spawnRangeHorizontal = 200f;
    [SerializeField] float spawnRangeVertical = 150f;
    [SerializeField] int collectibleCount;

    void Start()
    {
       InvokeRepeating("SpawnCollectible", 0.5f, 3f); 
    }


   void SpawnCollectible ()
    {           
        GameObject newG = Instantiate(collectiblePrefab, GenerateSpawnPosition(), collectiblePrefab.transform.rotation);
        newG.transform.localScale = GenerateSpawnSize();
    }

    private Vector3 GenerateSpawnPosition()
    {
        int offsetZ = 1400;

        float spawnPosX = Random.Range(-spawnRangeHorizontal, spawnRangeHorizontal);
        float spawnPosY = Random.Range(-spawnRangeVertical, spawnRangeVertical);
        float spawnPosZ = Random.Range(powerUpPrefab.transform.position.z + offsetZ, powerUpPrefab.transform.position.z + (offsetZ*2)) ;

        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY , spawnPosZ);
        return randomPos;
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
