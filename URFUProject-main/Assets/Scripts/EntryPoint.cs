using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _spawner;

    private void Start()
    {
        _player.Init();
        _spawner.Init(_player);
    }
}

