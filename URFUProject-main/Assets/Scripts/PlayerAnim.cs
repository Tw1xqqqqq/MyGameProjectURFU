using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private readonly int _walk = Animator.StringToHash("IsWalk");
    private readonly int _shoot = Animator.StringToHash("IsShoot");

    [SerializeField] private Animator _animator;

    public void StartWalk() => _animator.SetBool(_walk, true);
    public void StopWalk() => _animator.SetBool(_walk, false);

    public void StartShoot() => _animator.SetBool(_shoot, true);
    public void StopShoot() => _animator.SetBool(_shoot, false);
}
