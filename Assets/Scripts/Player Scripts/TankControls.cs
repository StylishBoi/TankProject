using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankControls : MonoBehaviour
{
    //Define the turn and drive speed of the tank
    [SerializeField] private float _linearSpeed = 4f;
    [SerializeField] private float _rollSpeed = 8f;
    
    //Input values for the turn and drive actions
    private float _moveInput;
    private float _spinInput;
    
    //Takes the tank body (Will be used for movement)
    private Rigidbody _rigidbody;
    
    //Helps to determine the sound of the tank
    private AudioManager _tankAudio;
    private Timer _timer;
    
    void Start()
    {
        //Gets access to the tank body + Access to the audio script
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            Debug.LogWarning("No rigidbody attached");
        }
        _tankAudio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    }
    
    void FixedUpdate()
    {
        //Makes the player move or turn
        _rigidbody.AddForce(transform.forward * (_moveInput*_linearSpeed)); 
        _rigidbody.AddRelativeTorque(0, _spinInput * _rollSpeed, 0);
    }

    void OnMovement(InputValue value)
    {
        //Get the value for movement
        _moveInput = value.Get<float>();
    }
    
    void OnSpinning(InputValue value)
    {
        //Get the value for movement
        _spinInput = value.Get<float>();
    }
    public void PlayerDeath()
    {
        //Ends the game + Kills the tank
        _timer.StopGame();
        Destroy(gameObject,0);
        _tankAudio.StopBGM();
        _tankAudio.PlaySfx(_tankAudio.gameover);
    }
}

