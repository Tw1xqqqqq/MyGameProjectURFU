using System.Collections;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _maxEnemyCountOnLevel;
    [SerializeField] private NextLevel _nextLevel;
    
    private Player _player;
    private Pool<Enemy> _pool;
    private bool _canSpawn = true;
    private int _currentEnemyCount;

    public int MaxEnemyCountOnLevel => _maxEnemyCountOnLevel;
    public void Init(Player player)
    {
        _player = player;
        StartSpawn();
    }

    private void StartSpawn()
    {
        _pool = new Pool<Enemy>(_enemy, transform, _maxEnemyCountOnLevel);
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (_currentEnemyCount < _maxEnemyCountOnLevel)
        {
            yield return new WaitForSeconds(_spawnInterval);
            
            Enemy enemy = _pool.GetFreeElement();
            enemy.gameObject.SetActive(true);
            enemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].position;
            enemy.Init(_player);
            _currentEnemyCount++;
        }
    }
}
