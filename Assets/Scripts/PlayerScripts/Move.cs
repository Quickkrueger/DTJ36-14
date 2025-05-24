using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    public float _moveSpeed = 10f;
    Vector3 _moveDirection = Vector2.zero;
    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void SetMovement(CallbackContext callback)
    {
        Vector2 moveVector = callback.ReadValue<Vector2>();

        _moveDirection.x = moveVector.x;
        _moveDirection.z = moveVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.MovePosition(transform.position + _moveDirection * Time.deltaTime * _moveSpeed);
    }
}
