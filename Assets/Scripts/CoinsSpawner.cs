using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _spawnPeriod = 5f;
    [SerializeField] private float _spawnRadius = 2f;

    private Coroutine _spawnProcess;
   
    void Start()
    {
        _spawnProcess = StartCoroutine(SpawnProcess());
    }

    private IEnumerator SpawnProcess()
    {
        var timePeriod = new WaitForSeconds(_spawnPeriod);

        while(true)
        {
            yield return timePeriod;
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition = Random.insideUnitCircle * _spawnRadius;
        spawnPosition += this.transform.position;
        GameObject.Instantiate(_coinPrefab, spawnPosition, Quaternion.identity);
    }
}
