using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private int startHp = 5;

    private int _hp;
    
    AudioManager _audioManager;
    WinCondition _wincondition;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _wincondition = GameObject.FindGameObjectWithTag("WinCondition").GetComponent<WinCondition>();
    }    
    void Start()
    {
        //This is weird, might need to change
        _hp=startHp;
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        _audioManager.PlaySfx(_audioManager.hit);
        if (_hp <= 0)
        {
            //When enemy dies, decrease the total and destroy the object
            _wincondition.Total_Updated();
            _audioManager.PlaySfx(_audioManager.death);
            Destroy(gameObject);
        }
        
    }
    
}
