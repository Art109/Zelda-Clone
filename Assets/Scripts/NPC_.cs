using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_ : MonoBehaviour, IInteractable
{
    string npc_name = "Zé Cabeca de Ovo";
    [SerializeField] DialogBox dialogController;
    [SerializeField] GameObject dialogBox;

    [TextArea]
    [SerializeField] string dialog;

    void Start()
    {
        dialog += npc_name;
    }


    public void Interact()
    {
        if (dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(false);
        }
        else
        {
            dialogBox.SetActive(true);
            StartCoroutine(dialogController.TypeDialog(dialog));

        }
    }

    public void CancelInteraction()
    {
        if (dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(false);
        }
    }
}
