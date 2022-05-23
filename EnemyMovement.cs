using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody enemyRB;
    GameObject player;
    [SerializeField] Collider enemyCollider;
    float enemySpeed = 50f;



    void Start()
    {

        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    void Update()
    {
        Vector3 targetDirection = (player.transform.position - transform.position);
        enemyRB.AddForce(targetDirection.normalized * enemySpeed);

        
        if(gameObject.transform.position.z < player.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
