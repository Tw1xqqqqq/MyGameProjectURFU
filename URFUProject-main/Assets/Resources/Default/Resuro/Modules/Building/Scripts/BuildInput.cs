using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInput : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _placementMask;
    [SerializeField] private float _maxDistance;
    private Vector3 _lastPosition;

    public Vector3 GetSelectedPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _camera.nearClipPlane;
        
        Ray ray = _camera.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _maxDistance, _placementMask))
        {
            _lastPosition = hit.point;
        }

        return _lastPosition;
    }
}
