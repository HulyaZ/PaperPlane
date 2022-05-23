using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject enemyExplosionParticles;
    [SerializeField] GameObject enemyHitParticles;
    [SerializeField] Transform parent;
        
    int scoreToInc = 5;
   [SerializeField] int hitPoints = 12;

    ScoreBoard scoreBoard;

    Animator enemyAnim;

    void Start()
    {  
        scoreBoard = FindObjectOfType<ScoreBoard>();
        enemyAnim = GetComponent<Animator>();

    }
    void Update()
    {


    }

    void OnParticleCollision(GameObject other)
    {
        
        if (other.tag == "Fire")
        {
            ProcessHit();   Debug.Log("hiiit");
         

            if (hitPoints < 1)
            {
                other.SetActive(false);
                KillEnemy();
            }   
        }
    }
    void ProcessHit()
    {
        hitPoints --;
        enemyAnim.SetBool("isHit", true); 
        StartCoroutine(waitFor(0.2f));   
    }

    void KillEnemy()
    {
        
        GameObject VFX = Instantiate(enemyExplosionParticles, transform.position, Quaternion.identity);
        scoreBoard.IncreaseScore(scoreToInc);

        VFX.transform.parent = parent;
        Destroy(gameObject); 
    }

    IEnumerator waitFor(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        enemyAnim.SetBool("isHit", false);
    }

}
