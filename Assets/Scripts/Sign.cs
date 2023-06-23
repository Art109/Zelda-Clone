using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] DialogBox dialogController;

    [TextArea]
    [SerializeField] string dialog;


    bool playerInRange;


    
    // Update is called once per frame
    void Update()
    {

        if (playerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            if(dialogBox.activeInHierarchy) 
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
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        { 
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
