using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeData : MonoBehaviour
{
    private float _currentChanceSplit = 100f;
    private float _chanceReductionMultiplier = 2f;
    private float _reductionFactor = 0.5f;

    public float CurrentChanceSplit => _currentChanceSplit;

    public void Init(float previousChance, Vector3 previousScale)
    {
        SetChance(previousChance);
        SetScale(previousScale);
        SetRandomColor();
    }

    private void SetChance(float chance)
    {
        _currentChanceSplit = chance / _chanceReductionMultiplier;
    }

    private void SetScale(Vector3 scale)
    {
        transform.localScale = scale * _reductionFactor;
    }

    private void SetRandomColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
