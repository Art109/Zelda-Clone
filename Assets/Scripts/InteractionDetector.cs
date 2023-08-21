using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    List<IInteractable> interactables = new List<IInteractable>();
    int selection = 0;

    // Update is called once per frame
    void Update()
    {
        if (interactables.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                interactables[selection].Interact();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                selection++;
                if (selection >= interactables.Count)
                {
                    selection = 0;
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                selection--;
                if(selection < 0 )
                {
                    selection = interactables.Count - 1;
                }
            }
            else if(Input.GetKeyDown(KeyCode.X))
            {
                interactables[selection].CancelInteraction();
            }
        }
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var interactable = collision.GetComponent<IInteractable>();
        if (interactable != null)
        {
            
            if (!interactables.Contains(interactable))
            {
                interactables.Add(interactable);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var interactable = collision.GetComponent<IInteractable>();
        if (interactable != null)
        {
            if (interactables.Contains(interactable))
            {
                interactables.Remove(interactable);
                Debug.Log(interactables.Count);
            }
        }

        if (interactables.Count == 0)
        {
            selection = 0;
        }
    }
}
