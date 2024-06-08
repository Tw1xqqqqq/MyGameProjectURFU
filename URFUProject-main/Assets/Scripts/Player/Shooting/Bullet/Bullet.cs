using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _lifeTime;

    private float _damage;
    
    public void Init(Vector3 velocity,float damage)
    {
        _rigidbody.velocity = velocity;
        _damage = damage;
        StartCoroutine(BulletDestroyer());
    }

    private IEnumerator BulletDestroyer()
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out IDamageable enemy))
        {
            enemy.ApplyDamage(_damage);
        }

        gameObject.SetActive(false);
    }
    
}