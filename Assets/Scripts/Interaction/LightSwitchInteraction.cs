using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitchInteraction : MonoBehaviour
{
    private bool playerNearby = false;
    private PlayerController pc;

    [SerializeField] private GameObject _light;
    private FlickerLight _fl;

    [Header("Actions")]
    [SerializeField] private InputActionReference _interactAction;

    void Awake()
    {
        _interactAction.action.Enable();
        _interactAction.action.performed += ToggleLightSwitch;

        _fl = _light.GetComponent<FlickerLight>();
    }

    void OnDestroy()
    {
        _interactAction.action.Disable();
        _interactAction.action.performed -= ToggleLightSwitch;
    }

    void ToggleLightSwitch(InputAction.CallbackContext context)
    {
        if (pc != null && _fl != null && playerNearby)
        {
            _fl.ToggleOnOff();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            pc = other.gameObject.GetComponent<PlayerController>();
            pc.ShowLightSwitchInteractionText();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            pc.ClearInteractionText();
            pc = null;
        }
    }
}
