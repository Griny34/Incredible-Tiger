using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private RuneMovement[] _prefabRunes;
    [SerializeField] private Transform[] _spawners;
    [SerializeField] private float _spawnTime;

    private float _currentDelay;

    private void Update()
    {
        _currentDelay += Time.deltaTime;

        if(_currentDelay >= _spawnTime)
        {
            CreateRunes();
            _currentDelay = 0;
        }
    }

    private void CreateRunes()
    {
        int numberRune = Random.Range(0, _prefabRunes.Length);
        int numberSpawner = Random.Range(0, _spawners.Length);

        Instantiate(_prefabRunes[numberRune], _spawners[numberSpawner].position, Quaternion.identity);
    }
}
