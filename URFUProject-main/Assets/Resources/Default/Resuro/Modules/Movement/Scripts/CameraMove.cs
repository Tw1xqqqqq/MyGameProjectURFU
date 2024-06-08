using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject _maicharecter;

    [SerializeField] private float _returnSpeed;
    [SerializeField] private float _height;
    [SerializeField] private float _rearDistance;

    private Vector3 currentVector;

    void Start()
    {
        transform.position = new Vector3(_maicharecter.transform.position.x, _maicharecter.transform.position.y + _height, _maicharecter.transform.position.z - _rearDistance);
        transform.rotation = Quaternion.LookRotation(_maicharecter.transform.position - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
    }


    void CameraMovement()
    {
        currentVector = new Vector3(_maicharecter.transform.position.x, _maicharecter.transform.position.y + _height, _maicharecter.transform.position.z - _rearDistance);
        transform.position = Vector3.Lerp(transform.position, currentVector, _returnSpeed * Time.deltaTime);
    }
}
