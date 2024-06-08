using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _range;
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject _gun;

    private int _bullet = 30;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _bullet = 30;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (_bullet > 0)
            {
                Shoot();
                _bullet--;
            }
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_gun.transform.position, _gun.transform.forward, out hit, _range))
        {
            if (hit.rigidbody != null)
            {

                hit.rigidbody.AddForce(-hit.normal * 150);
            }
        }
    }

}
