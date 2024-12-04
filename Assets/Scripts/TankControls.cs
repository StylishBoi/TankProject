using UnityEngine;
using UnityEngine.InputSystem;

public class TankControls : MonoBehaviour
{
    [SerializeField] private float _linearSpeed = 4f;
    [SerializeField] private float _rollSpeed = 8f;
    
    private float _moveInput;
    private float _spinInput;
    private bool _isalive=true;
    
    private Rigidbody _rigidbody;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            Debug.LogWarning("No rigidbody attached");
        }
    }
    
    void Update()
    {
        _rigidbody.AddForce(transform.forward * (_moveInput*_linearSpeed)); 
        _rigidbody.AddRelativeTorque(0, _spinInput * _rollSpeed, 0);
    }

    void OnMovement(InputValue value)
    {
        //Get the value for movement
        _moveInput = value.Get<float>();
        
        Debug.LogWarning(_moveInput*_linearSpeed);
    }
    
    void OnSpinning(InputValue value)
    {
        //Get the value for movement
        _spinInput = value.Get<float>();
    }
    public void PlayerDeath()
    {
        //Enable the player death
        _isalive = false;
        if (_isalive == false)
        {
            Destroy(gameObject,0);
        }
    }
}

