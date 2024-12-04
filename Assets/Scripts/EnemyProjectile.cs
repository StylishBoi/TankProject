using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float bulletForce = 50f;
    
    AudioManager _audioManager;
    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
            objective.PlayerDeath();
            Destroy(this.gameObject);
            _audioManager.StopBGM();
            _audioManager.PlaySfx(_audioManager.gameover);
        }
    }
}
