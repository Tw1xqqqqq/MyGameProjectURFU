using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _movementSpeed;
    private void Update()
    {
        Roatate();
        Move();
    }

    private void Roatate()
    {
        float rotation = Input.GetAxis(Horizontal);

        transform.Rotate(rotation * _rotateSpeed * Time.deltaTime * Vector3.up);
    }

    private void Move()
    {
        float direction = Input.GetAxis (Vertical);
        float distance = direction * _movementSpeed * Time.deltaTime;

        transform.Translate(distance * Vector3.forward);
    }
}
