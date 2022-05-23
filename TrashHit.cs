using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashHit : MonoBehaviour
{
 
    [SerializeField] Transform parent;

    int scoreToInc = 5;
    [SerializeField] int hitPoints = 12;

    ScoreBoard scoreBoard;


    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();

    }
 

    void OnParticleCollision(GameObject other)
    {

        if (other.tag == "Fire")
        {
            ProcessHit(); Debug.Log("hiiit");


            if (hitPoints < 1)
            {
                other.SetActive(false);
                KillEnemy();
            }
        }
    }
    void ProcessHit()
    {
        hitPoints--;
        StartCoroutine(waitFor(0.2f));
    }

    void KillEnemy()
    {

        scoreBoard.IncreaseScore(scoreToInc);

        Destroy(gameObject);
    }

    IEnumerator waitFor(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);

    }
}
