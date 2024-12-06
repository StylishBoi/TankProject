using UnityEngine;
using UnityEngine.InputSystem;

public class TankTopHalf : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 1f;
    private float _turnInput;
    
    void FixedUpdate()
    {
        //Rotates the canon
        transform.Rotate(turnSpeed*_turnInput,0, 0);
    }
    
    void OnCanonSpin(InputValue value)
    {
        //Intake the input to make the canon spin
        _turnInput = value.Get<float>();
    }
}
