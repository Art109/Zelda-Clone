using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour, IDamageable
{
    [SerializeField]int hp = 3;

    public void Die()
    {
      if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        hp -= damage;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
