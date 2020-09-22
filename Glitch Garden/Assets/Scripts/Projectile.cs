using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] int damage = 50;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }


    private void OnTriggerEnter2D(Collider2D collidedWith)
    {
        var health = collidedWith.GetComponent<Health>();
        var attacker = collidedWith.GetComponent<Attacker>();

        if (attacker && health)
        {
           health.DealDamage(damage);
           Destroy(gameObject);
        }
    }
}
