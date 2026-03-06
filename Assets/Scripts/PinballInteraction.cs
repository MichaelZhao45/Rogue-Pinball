using UnityEngine;
using UnityEngine.InputSystem;

public class PinballInteraction : MonoBehaviour
{
    private bool playerNearby = false;
    private bool inPinballMode = false;

    void Update()
    {
        if (playerNearby && !inPinballMode && Keyboard.current.eKey.wasPressedThisFrame)
        {
            inPinballMode = true;
        }

        if (inPinballMode && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
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