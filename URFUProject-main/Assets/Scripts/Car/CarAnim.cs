using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnim : MonoBehaviour
{
    private readonly int _openDoor = Animator.StringToHash("OpenDoor");
    private readonly int _closeDoor = Animator.StringToHash("CloseDoor");

    [SerializeField] private Animator _animator;

    public void OpenDoor() => _animator.SetTrigger(_openDoor);
    public void CloseDoor() => _animator.SetTrigger(_closeDoor);

}
