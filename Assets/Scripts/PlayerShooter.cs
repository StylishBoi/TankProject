using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;

    private float _Cooldown;
    private Coroutine _shootRoutine;
    
    AudioManager _audioManager;
    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }  

    void Update()
    {
        //Updates the cooldown with how much time has gone by
        _Cooldown += Time.deltaTime;
    }
    IEnumerator Fire()
    {
        while (true)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            
            yield return new WaitForSeconds(fireRate);
        }
    }

    void OnShoot(InputValue value)
    {
        if (value.isPressed && _Cooldown>fireRate)
        {
            if(_shootRoutine!=null)
            {
                
                StopCoroutine(_shootRoutine);
            }
            _shootRoutine=StartCoroutine("Fire");
            _audioManager.PlaySfx(_audioManager.shoot);
            //Reset the cooldown to 0
            _Cooldown=0;
        }
        else
        {
            StopCoroutine("Fire");
            _shootRoutine = null;
        }
    }
}
