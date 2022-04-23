using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private GameObject _ballPrefab;

    private float _timer;
    private bool _isReady;

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer<=0)
        {
            _timer = _spawnDelay;
            _isReady = true;
        }

        if (_isReady)
        {
            _isReady = false;

            Instantiate(_ballPrefab, transform.position, Quaternion.identity);
        }
    }
}
