using UnityEngine;

public class MovementData
{
    private float _speed;
    private Vector3 _direction;
    private float _velocity;
    
    public Vector3 Direction { get => _direction; set => _direction = value; }
    public float Speed {get => _speed; set => _speed = value; }
}
