using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody playerRB;
    [SerializeField] GameObject firingParticles;


    float forwardSpeed = 90f;
    float horizontalSpeed = 80f;
    float verticalSpeed = 80f;

    float speedFactor = 3;

    bool isSpeededUp = false;

    // Screen bounds
    float xRange = 200f;
    float yRange = 200f;

    public float xThrow, yThrow;

    // Player Rotation vars
    float pitchFactor = 0f;
    float yawFactor = 18f;
    float controlPitchFactor = -15f;
    float controlRollFactor = -20f;


    private void Update()
    {
        ProcessFiring();
        ToggleSpeedUp();
    }
    void FixedUpdate()
    {
        ProcessMovement();
        ProcessRotation();
    }

    private void ProcessMovement() // Player movement
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * horizontalSpeed;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * verticalSpeed;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);


        playerRB.transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
        playerRB.AddForce(Vector3.forward * forwardSpeed);

    }

    private void ProcessRotation() // Player rotation
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float pitchRelativeToPosition = transform.localPosition.y * pitchFactor;
        float pitchRelativeToThrow = yThrow * controlPitchFactor;
        float pitch = pitchRelativeToPosition + pitchRelativeToThrow;

        float yaw = yawFactor * xThrow;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ToggleSpeedUp()  // Increases and decreases speed by a factor of speedFactor
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            forwardSpeed = forwardSpeed * speedFactor;
            horizontalSpeed = horizontalSpeed * speedFactor;
            verticalSpeed = verticalSpeed * speedFactor;
            isSpeededUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            forwardSpeed = forwardSpeed / speedFactor;
            horizontalSpeed = horizontalSpeed / speedFactor;
            verticalSpeed = verticalSpeed / speedFactor;
            isSpeededUp = false;
        }

    }


    private void ProcessFiring() // Fire toggle
    {
        if (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space))
        {
            firingParticles.SetActive(true);
            SetLasersActive(true);
        }

        else
        {
            SetLasersActive(false);
        }
    }

    private void SetLasersActive(bool isActive) // Enables particles
    {
        
            var emmisionModule = firingParticles.GetComponent<ParticleSystem>().emission;
            emmisionModule.enabled = isActive;

           
        
    }


}


