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
        if (IsSplitFailed(cube))
        {
            ExplodeOnly(cube);

            return;
        }

        List<Rigidbody> spawnedRigidbodies = SpawnCubes(cube);
        _exploder.Boom(spawnedRigidbodies);
        Destroy(cube.gameObject);
    }

    private bool IsSplitFailed(Cube cube)
    {
        float roll = Random.Range(0f, 100f);

        return roll >= cube.CurrentChanceSplit;
    }

    private void ExplodeOnly(Cube cube)
    {
        Vector3 pos = cube.transform.position;
        float scale = cube.transform.localScale.x;

        float force = 500f / scale;
        float radius = 5f / scale;
        float upwards = 1f;

        _exploder.Boom(pos, force, radius, upwards);
        Destroy(cube.gameObject);
    }

    private List<Rigidbody> SpawnCubes(Cube original)
    {
        List<Rigidbody> rigidbodies = new();
        Vector3 spawnPos = original.transform.position;
        int count = Random.Range(_minNumberObject, _maxNumberObject + 1);

        for (int i = 0; i < count; i++)
        {
            Cube newCube = Instantiate(_prefab, spawnPos, Quaternion.identity).GetComponent<Cube>();
            newCube.Init(original.CurrentChanceSplit, original.transform.localScale, _colorChanger.RandomColor);
            rigidbodies.Add(newCube.GetComponent<Rigidbody>());
        }

        return rigidbodies;
    }
}
