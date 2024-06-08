using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour,IDamageable
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _damage = 5;
    
    private ITargetable _target;
    private NavMeshAgent _agent;
    private Health _health;
    private NextLevel _nextLevel;

    public void ApplyDamage(float damage)
    {
        _health.DecreaseHealth(damage);
    }
    
    private void Awake()
    {
        _nextLevel = FindObjectOfType<NextLevel>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.SetDestination(_target.Position);
    }

    public void Init(ITargetable target)
    {
        _target = target;
        _health = new Health(_maxHealth);
        _health.Die += OnDied;
    }

    private void OnDied()
    {
        Deactivate();
    }

    private void Deactivate()
    {
        _nextLevel.CheckZombie();
        _health.Die -= OnDied;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }
    }
}