using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private float _currentChanceSplit = 100f;
    private float _chanceReductionMultiplier = 2f;
    private float _reductionFactor = 0.5f;

    public float CurrentChanceSplit => _currentChanceSplit;

    public void Init(float previousChance, Vector3 previousScale, Color color)
    {
        Renderer renderer = GetComponent<Renderer>();

        SetChance(previousChance);
        SetScale(previousScale);
        renderer.material.color = color;
    }

    private void SetChance(float chance)
    {
        _currentChanceSplit = chance / _chanceReductionMultiplier;
    }

    private void SetScale(Vector3 scale)
    {
        transform.localScale = scale * _reductionFactor;
    }
}
