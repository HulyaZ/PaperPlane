using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    int destroyTime = 15;

    void Update()
    {
        StartCoroutine(CollectiblesCountDownRoutine());
    }

    IEnumerator CollectiblesCountDownRoutine()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
