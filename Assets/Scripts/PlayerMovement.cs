using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _cam;
    [SerializeField] private float _speedAceleration;
    
    public float Speed;
    public float RotationSpeed;

    private void Update()
    {
        MovingFast();
    }

    private void FixedUpdate()
    {
        Moving();
        Rotating();
    }

    private void Moving()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical).normalized * Speed;
        if (move.magnitude >= 0.1f)
        {
            _controller.Move(transform.TransformVector(move) * Speed * Time.deltaTime);
        }
    }

    private void MovingFast()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed += _speedAceleration;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed -= _speedAceleration;
        }
    }

    private void Rotating()
    {
        float mouseRotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseRotation * RotationSpeed * Time.deltaTime, 0);
    }
}