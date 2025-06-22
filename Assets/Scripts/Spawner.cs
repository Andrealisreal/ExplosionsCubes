using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _plane;
    [SerializeField] private GameObject _prefab;

    private GameObject _cube;

    private float _min = -5f;
    private float _max = 5f;

    private float _initialSplitChance = 100f;
    private float _currentSplitChance = 100f;

    public void Boom()
    {
        int count = Random.Range(2, 7);
        float roll = Random.Range(0f, _initialSplitChance);

        if (roll <= _currentSplitChance)
        {
            for (int i = count; i > 0; i--)
            {
                float posX = Random.Range(_min, _max);
                float posZ = Random.Range(_min, _max);

                Vector3 spawnPosition = new Vector3(posX, 2, posZ);

                _cube = Instantiate(_prefab, spawnPosition, Quaternion.identity);
                _cube.transform.localScale *= 0.5f;

                Spawner newSpawner = _cube.GetComponent<Spawner>();

                newSpawner.SetSplitChance(_currentSplitChance / 2f);
            }
        }

        Destroy(gameObject);
    }

    public void SetSplitChance(float value)
    {
        _currentSplitChance = value;
    }
}
