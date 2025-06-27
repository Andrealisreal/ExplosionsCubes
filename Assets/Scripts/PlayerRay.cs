using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private Ray _ray;
    private RaycastHit _hit;

    private InputReader _input;

    private bool _hasHitValidTarget = false;

    private void Awake()
    {
        _input = GetComponent<InputReader>();
    }

    private void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _hasHitValidTarget = false;

        if (Physics.Raycast(_ray, out _hit))
            if (_hit.collider.TryGetComponent<CubeData>(out _))
                _hasHitValidTarget = true;
    }

    private void OnEnable()
    {
        _input.MouseClicked += SelectObject;
    }

    private void OnDisable()
    {
        _input.MouseClicked -= SelectObject;
    }

    private void SelectObject()
    {
        if (_hasHitValidTarget == false)
            return;

        if (_hit.collider.TryGetComponent<CubeData>(out CubeData cubeData))
            _spawner.Split(cubeData);
    }
}
