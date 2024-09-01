using Unity.VisualScripting;
using UnityEngine;

// Ensure the component is present on the gameobject the script is attached to
// Uncomment this if you want to enforce the object to require the RB2D component to be already attached
// [RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    public HealthController healthController;
    [SerializeField] private InteractionsController interactionsController;

   [HideInInspector] public bool canInteract = false;
    private bool interacting = false;
    private void Start()
    {
        ChangeExperienceMode(true);
    }

    private void Update()
    {
        if (canInteract) {
            if (Input.GetKeyDown(KeyCode.E) && !interacting) 
            {
                ChangeExperienceMode(false);
            }
            else if(Input.GetKeyDown(KeyCode.Escape) && interacting)
            {
                ChangeExperienceMode(true);
            }
        }
    }
    private void ChangeExperienceMode(bool canMove)
    {
        if (canMove) 
        {
            playerMovement.gameObject.SetActive(true);
            interactionsController.gameObject.SetActive(false);
            interacting = false;
            print("Fin de la interaccion");
        }
        else
        {
            playerMovement.gameObject.SetActive(false);
            interactionsController.gameObject.SetActive(true);
            interacting = true;
            print("Interactuando");
        }
    }
}