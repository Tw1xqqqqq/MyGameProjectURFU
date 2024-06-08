using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject.SpaceFighter;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour,ITargetable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private PlayerAnim _playerAnim;
    [SerializeField] private Canvas _loose;
    
    private CharacterController _characterController;
    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    
    public CharacterController CharacterController => _characterController;
    public PlayerInput Input => _input;
    public Vector3 Position => transform.position;
    public Health Health { get; private set; }

    public PlayerAnim PlayerAnim => _playerAnim;

    public void ApplyDamage(float damage)
    {
       Health.DecreaseHealth(damage);
    }
    
    public void Init()
    {
        Health = new Health(_maxHealth);
        Health.Die += OnDied;
    }

    private void OnDied()
    {
        Health.Die -= OnDied;
        StartCoroutine(Loose());
    }

    IEnumerator Loose()
    {
        _loose.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();

}
