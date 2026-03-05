using UnityEngine;
using UnityEngine.InputSystem;

public class PinballInteraction : MonoBehaviour
{
    public GameObject fpsCamera;
    public GameObject pinballCamera;

    private bool playerNearby = false;
    private bool inPinballMode = false;

    void Update()
    {
        if (playerNearby && !inPinballMode && Keyboard.current.eKey.wasPressedThisFrame)
        {
            fpsCamera.SetActive(false);
            pinballCamera.SetActive(true);
            inPinballMode = true;
        }

        if (inPinballMode && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            pinballCamera.SetActive(false);
            fpsCamera.SetActive(true);
            inPinballMode = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}