using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Canvas _winCanvas;
    
    private int _maxCountZombie;
    private int _killCount;

    private void Awake()
    {
        _maxCountZombie = _spawner.MaxEnemyCountOnLevel;
    }

    public void CheckZombie()
    {
        _killCount++;
        if(_killCount == _maxCountZombie)
            StartCoroutine(NextLevelTransition());
    }
    IEnumerator NextLevelTransition()
    {
        _winCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
