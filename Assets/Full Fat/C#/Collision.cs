using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameManager gameManager;
    public CinematicShake cinematicShake;
    public Player movement;

    [Header("Sounds")]
    public AudioClip crash;

    AudioSource Source;

    public void Awake()
    {
        Source = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (movement.enabled == false)
        {
            Invoke("WaitSeconds", 1f);
        }
    }

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            StartCoroutine(cinematicShake.Shake(.15f, .05f));
            Source.clip = crash;
            Source.Play();
        }
    }

    public void WaitSeconds()
    {
        movement.enabled = false;
        gameManager.Dead();
        
    }
}
