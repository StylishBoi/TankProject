using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float bulletForce = 50f;
    UIManager _uiManager;
    
    private void Awake()
    {
        //Gets tank compoment to later use for the tank death
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }  
    
    void Start()
    {
        //Creates a bullet
        GetComponent<Rigidbody>().linearVelocity = transform.forward * bulletForce;
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter(Collision other)
    {
        //When collision, enable player death + destroy the projectile
        if (other.gameObject.TryGetComponent(out TankControls objective))
        {
            _uiManager.DeathScreen();
            objective.PlayerDeath();
            Destroy(this.gameObject);
        }
    }
}
