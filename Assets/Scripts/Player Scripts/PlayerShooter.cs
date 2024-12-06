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
    
    
    void FixedUpdate()
    {
        //Updates the cooldown with how much time has gone by
        _Cooldown += Time.deltaTime;
    }
    IEnumerator Fire()
    {
        //Makes the player shoot
        while (true)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            
            yield return new WaitForSeconds(fireRate);
        }
    }

    void OnShoot(InputValue value)
    {
        //Checks if the player can shoot or not
        if (value.isPressed && _Cooldown>fireRate)
        {
            if(_shootRoutine!=null)
            {
                
                StopCoroutine(_shootRoutine);
            }
            _shootRoutine=StartCoroutine("Fire");
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
