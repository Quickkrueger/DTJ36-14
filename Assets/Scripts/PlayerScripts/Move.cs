using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    public float _moveSpeed = 10f;
    Vector3 _moveDirection = Vector2.zero;
    Rigidbody _rb;
    Animator _animator;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

    }
    public void SetMovement(CallbackContext callback)
    {
        Vector2 moveVector = callback.ReadValue<Vector2>();

        Vector3 moveDirection = new Vector3(moveVector.x, 0, moveVector.y);

        transform.LookAt(transform.position + moveDirection);
        if (moveDirection.sqrMagnitude > 0)
        {
            _animator.SetFloat("Speed", 1);
            _animator.speed = _moveSpeed;
        }
        else
        {
            _animator.SetFloat("Speed", 0);
            _animator.speed = 1;
        }

    }

    // Update is called once per frame
}
