using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    [SerializeField] int speed = 250;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(enemy.transform.forward * Time.deltaTime * speed); 
    }
}
