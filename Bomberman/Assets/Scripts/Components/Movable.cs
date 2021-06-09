using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector3 inputDirection;
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + inputDirection.normalized * moveSpeed * Time.fixedDeltaTime);
        //transform.position += inputDirection.normalized * moveSpeed * Time.deltaTime;
        inputDirection = Vector3.zero;
    }

    public void SetDirection(Vector3 directionVector)
    {
        inputDirection = directionVector;
    }

    public void SetForwardAxis(float value)
    {
        inputDirection.z = value;
    }

    public void SetRightAxis(float value)
    {
        inputDirection.x = value;
    }

    public void SetUpAxis(float value)
    {
        inputDirection.y = value;
    }
}
