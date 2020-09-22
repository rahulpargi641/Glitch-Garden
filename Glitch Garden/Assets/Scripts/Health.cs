using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    void TriggerDeathVFX()
    {
       GameObject deathVfxObj =  Instantiate(deathVFX, transform.position, transform.rotation);
       Destroy(deathVfxObj, 1f);
    }
}
