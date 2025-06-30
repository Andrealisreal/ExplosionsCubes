using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ColorChanger _colorChanger;

    private int _minNumberObject = 2;
    private int _maxNumberObject = 7;

    public void Split(Cube cube)
    {
        float cubeScale = cube.transform.localScale.x;

        float minPercentageSpawn = 0f;
        float maxPercentageSpawn = 100f;
        float explosionForce = 500f / cubeScale;
        float explosionRadius = 5f / cubeScale;
        float upwardsModifier = 1f;

        float roll = Random.Range(minPercentageSpawn, maxPercentageSpawn + 1);

        if (roll >= cube.CurrentChanceSplit)
        {
            Destroy(cube.gameObject);
            _exploder.Boom(cube.transform.position, explosionForce, explosionRadius, upwardsModifier);

            return;
        }

        List<Rigidbody> rigidbodys = new();
        Vector3 spawnPos = cube.transform.position;
        int count = Random.Range(_minNumberObject, _maxNumberObject + 1);

        for (int i = 0; i < count; i++)
        {
            Cube newCube = Instantiate(_prefab, spawnPos, Quaternion.identity).GetComponent<Cube>();
            newCube.Init(cube.CurrentChanceSplit, cube.transform.localScale, _colorChanger.RandomColor);
            rigidbodys.Add(newCube.GetComponent<Rigidbody>());
        }

        _exploder.Boom(rigidbodys);
        Destroy(cube.gameObject);
    }
}
