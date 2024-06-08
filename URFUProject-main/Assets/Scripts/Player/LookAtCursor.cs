using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class LookAtCursor : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private Camera _camera;

    private Vector3 _lookPosition;
    private Vector3 _mousePosition;
    private Vector3 _mouse;

    private void Update()
    {
        Aim();
    }

    public (bool, Vector3) GetMousePosition()
    {
        _mouse = Input.mousePosition;
        Ray ray = _camera.ScreenPointToRay(_mouse);
        return Physics.Raycast(ray, out var hit, 100f, _ground) ? (true, hit.point) : (false, Vector3.zero);
    }

    public void Aim()
    {
        (bool success, Vector3 position) = GetMousePosition();
        if (success)
        {
            Vector3 direction = position - transform.position;
            direction.y = 0f;
            var rotation = Quaternion.LookRotation(direction);
            transform.forward = Vector3.Lerp(transform.forward, direction, 5f * Time.deltaTime);
        }
    }


}
