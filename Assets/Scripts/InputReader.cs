using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    public event UnityAction MouseClicked;

    private InputController _input;

    private void Awake()
    {
        _input = new InputController();

        _input.Player.MouseClick.performed += context => Click();
    }

    private void OnEnable() =>
        _input.Enable();

    private void OnDisable() =>
        _input.Disable();

    private void Click() =>
        MouseClicked?.Invoke();
}
