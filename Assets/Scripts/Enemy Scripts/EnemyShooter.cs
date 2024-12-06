using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;

    private Coroutine shootRoutine;
    
    void Start()
    {
        //Enables the shooting repetition
        shootRoutine=StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        //Shoots infinitely, only limited by firerate
        while (true)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);;
            
            yield return new WaitForSeconds(fireRate);
        }
    }
}
