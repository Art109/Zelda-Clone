using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_ : MonoBehaviour, IInteractable
{
    string name = "Zé Rui Cabeca de Ovo";
    [SerializeField] DialogBox dialogController;
    [SerializeField] GameObject dialogBox;

    [TextArea]
    [SerializeField] string dialog;

    void Start()
    {
        dialog += name;
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
}
