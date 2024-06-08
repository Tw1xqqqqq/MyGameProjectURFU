using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private float maxRotationDistance;

    [SerializeField] private float rotationSpeed;
    void Update()
    {
        Vector3 position = Input.mousePosition;
        Vector3 a = _camera.ScreenToWorldPoint(position);
        transform.LookAt(a);

    }
}
