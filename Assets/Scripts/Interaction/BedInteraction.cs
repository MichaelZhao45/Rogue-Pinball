using UnityEngine;
using UnityEngine.InputSystem;

public class BedInteraction : MonoBehaviour
{
    private PlayerController pc;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pc = other.gameObject.GetComponent<PlayerController>();
            pc.ShowBedInteractionText();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pc.ClearInteractionText();
            pc = null;
        }
    }
}
