using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _cam;

    public float Speed;
    public float RotationSpeed;

    void Update()
    {
        MovingFast();
    }

    void FixedUpdate()
    {
        Moving();
        Rotating();
    }

    void Moving()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical).normalized * Speed;

        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _controller.Move(moveDir.normalized * Speed * Time.deltaTime);
        }
    }

    void MovingFast()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed += 5;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed -= 5;
        }
    }

    void Rotating()
    {
        float mouseRotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseRotation * RotationSpeed * Time.deltaTime, 0);
    }
}