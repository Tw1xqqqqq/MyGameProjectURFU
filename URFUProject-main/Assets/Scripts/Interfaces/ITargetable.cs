using UnityEngine;

public interface ITargetable : IDamageable
{
    public Vector3 Position { get; }
}