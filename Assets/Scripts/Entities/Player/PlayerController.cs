using Unity.VisualScripting;
using UnityEngine;

// Ensure the component is present on the gameobject the script is attached to
// Uncomment this if you want to enforce the object to require the RB2D component to be already attached
// [RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    public HealthController healthController;

   [HideInInspector] public bool canInteract = false;
    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E)) {

        }
    }
}