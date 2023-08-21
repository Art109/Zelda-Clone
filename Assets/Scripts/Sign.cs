using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] DialogBox dialogController;

    [TextArea]
    [SerializeField] string dialog;


    bool playerInRange;

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
        if(dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(false);
        }
    }
    
 
}
