using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espeto : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        IDamageable damageComponent = collision.gameObject.GetComponent<IDamageable>();
        
        if (damageComponent != null)
        {
            Debug.Log("Dano");
            damageComponent.takeDamage(1);
        }
    }


}
