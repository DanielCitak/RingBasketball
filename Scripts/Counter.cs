using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Counter : MonoBehaviour
{
    private GameManager gameManager;
    public ParticleSystem basketParticle;

    private void Start()
    {
        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            gameManager.UpdateScore();
            Destroy(other.gameObject);
            basketParticle.Play();
            
            gameManager.ActivateBoxes();
        }

    }
}
