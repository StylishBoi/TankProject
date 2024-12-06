using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float bulletForce = 50f;
    
    AudioManager _audioManager;
    private void Awake()
    {
        //Gets access to the audio script
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }  
 
    void Start()
    {
        //Creates a new bullet
        _audioManager.PlaySfx(_audioManager.shoot);
        GetComponent<Rigidbody>().linearVelocity = transform.forward * bulletForce;
        Destroy(gameObject,2);
    }

    private void OnCollisionEnter(Collision other)
    {
        //Destroy the bullet when colliding with an enemy + Damaging them
        if (other.gameObject.TryGetComponent(out Destructible objective))
        {
            Destroy(gameObject);
            objective.TakeDamage(1);
        }
    }
}
