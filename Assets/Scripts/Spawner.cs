using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Exploder _exploder;

    private int _minNumberObject = 2;
    private int _maxNumberObject = 7;

    public void Split(CubeData cubeData)
    {
        float minPercentageSpawn = 0f;
        float maxPercentageSpawn = 100f;

        float roll = Random.Range(minPercentageSpawn, maxPercentageSpawn + 1);

        if(roll >= cubeData.CurrentChanceSplit)
        {
            Destroy(cubeData.gameObject);
            return;
        }

        List<Rigidbody> rb = new();
        Vector3 spawnPos = cubeData.transform.position;
        int count = Random.Range(_minNumberObject, _maxNumberObject + 1);

        for (int i = 0; i < count; i++)
        {
            CubeData newData = Instantiate(_prefab, spawnPos, Quaternion.identity).GetComponent<CubeData>();
            newData.Init(cubeData.CurrentChanceSplit, cubeData.transform.localScale);
            rb.Add(newData.GetComponent<Rigidbody>());
        }

        _exploder.Boom(rb);
        Destroy(cubeData.gameObject);
    }
}
