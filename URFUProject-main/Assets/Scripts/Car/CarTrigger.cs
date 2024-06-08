using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CarTrigger : MonoBehaviour
{
    [SerializeField] private CarAnim _carAnim;

    private void OnTriggerEnter(Collider other)
    {
        _carAnim.OpenDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        _carAnim.CloseDoor();
    }
}
