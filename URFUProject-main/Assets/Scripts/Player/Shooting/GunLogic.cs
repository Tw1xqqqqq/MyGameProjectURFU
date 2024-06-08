using System.Collections;
using System.Runtime.InteropServices;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GunLogic : MonoBehaviour,IShootable
{
    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);
    
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _damage;
    [SerializeField] private float _maxSpread;
    [SerializeField] private int _bulletCount;
    [SerializeField] private Camera _camera;
    [SerializeField] private RectTransform _crosshair;
    [SerializeField] private PlayerAnim _playerAnim;

    private float _lastShootTime;
    private float _currentRecoil;
    private float _stepSpread;
    private int _currentBulletCount;
    private Vector3 _defaultCoordinate;
    private Vector3 _pos;
    private Vector3 _lastPosition;
    private Pool<Bullet> _pool;
    private float _movementMouseSpeed;
    private Vector2 _mousePos;
    private bool followMouse = true;
    private float number = 1.05f;
    private void Update()
    {
       
        Debug.Log("Маус позиитион = " +  Input.mousePosition);
        Debug.Log("Позиция пули = " +  _bulletPoint.position);

        Debug.Log("Рэй" + _lastPosition);
        if (Input.GetKey(KeyCode.F))
        {
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            _playerAnim.StartShoot();
            followMouse = !followMouse;
        }
        
        if (followMouse == true)
        {
            Vector3 mousePos = Input.mousePosition;
            _crosshair.position = mousePos;
        }

        
        if (Input.GetKeyUp(KeyCode.F))
        {
            _playerAnim.StopShoot();
            Transform cameraTransform = _camera.transform;
            cameraTransform.position = Vector3.Lerp(cameraTransform.position,_defaultCoordinate,1f);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            followMouse = !followMouse;
            _currentRecoil = _stepSpread;
            _currentBulletCount = 0;
            Transform cameraTransform = _camera.transform;
            cameraTransform.position = Vector3.Lerp(cameraTransform.position,_defaultCoordinate,1f);
        }
    }

    private void Start()
    {
        _pool = new Pool<Bullet>(_bullet,transform,30);
        _stepSpread = _maxSpread / _bulletCount;
        _defaultCoordinate = _camera.transform.position;
    }
    
    public void Shoot()
    {
        ShakeCamera();
        
        if (Time.time - _lastShootTime < _shootDelay || _currentBulletCount >= _bulletCount)
            return;

        _currentBulletCount++;
        _lastShootTime = Time.time;
        
        Vector3 velocity = _bulletPoint.forward * _bulletSpeed;
        
        float recoilX = Random.Range(-_currentRecoil,_currentRecoil);
        _currentRecoil += _stepSpread;
        
        Vector3 velocityWithRecoil = velocity + new Vector3(recoilX, 0f, 0f);
        
        Bullet bullet = _pool.GetFreeElement();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = _bulletPoint.position;
        bullet.Init(velocityWithRecoil, _damage);
        

        Vector3 direction = _bulletPoint.transform.TransformDirection(Vector3.right);
        Vector3 targetPosition = _bulletPoint.position + direction * 1f;
        _crosshair.position = targetPosition;
        
    }

    private void ShakeCamera()
    {
        Transform cameraTransform = _camera.transform;

        cameraTransform.DOShakePosition(0.1f, 0.05f, 1, 90f, false, true, ShakeRandomnessMode.Harmonic)
            .SetEase(Ease.InOutBounce).SetLink(cameraTransform.gameObject);
    }
}