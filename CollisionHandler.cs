using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    float reloadDelay = 1.5f;

    [HideInInspector] public bool isHalt;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] ParticleSystem fireParticles;
    [SerializeField] GameObject player;

    private void Start()
    {
          }


    private void OnCollisionEnter(Collision collision)
    {  
        if (collision.gameObject.tag == "Obstacle")
        {
            StartCrashSequence();
        }


    }

    private void StartCrashSequence()
    {
        GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        fireParticles.Stop();
        explosionParticles.Play();

        player.GetComponentInChildren<MeshRenderer>().enabled = false;

        Invoke("ReloadLevel", reloadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
