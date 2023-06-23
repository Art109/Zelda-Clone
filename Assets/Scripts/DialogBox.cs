using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogBox : MonoBehaviour
{

    [SerializeField] int lettersPerSecond;

    [SerializeField] Text dialogText;




    public void TextEnable()
    {
        dialogText.enabled = true;
    }

    public void TextDisable() 
    { 
        dialogText.enabled = false; 
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }
}
