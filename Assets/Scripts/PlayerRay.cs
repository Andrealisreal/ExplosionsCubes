using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    [SerializeField] private Transform _pointer;

    private Ray _ray;
    private RaycastHit _hit;
    private InputReader _input;
    private Spawner _spawner;
    private bool _hasHitValidTarget = false;

    private void Awake()
    {
        _input = GetComponent<InputReader>();
        _spawner = GetComponent<Spawner>();
    }

    private void LateUpdate()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _hasHitValidTarget = false;

        if (Physics.Raycast(_ray, out _hit))
        {
            _pointer.position = _hit.point;

            if (_hit.collider.TryGetComponent<Spawner>(out _))
                _hasHitValidTarget = true;
        }
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
        if (!_hasHitValidTarget)
            return;

        if (_hit.collider.TryGetComponent<Spawner>(out Spawner spawner))
            spawner.Boom();
    }
}
