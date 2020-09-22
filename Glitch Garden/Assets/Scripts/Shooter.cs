using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    void Start()
    {
        Debug.Log("Shooter");
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }
    // Start is called before the first frame update
  

    // Update is called once per frame
   private void Update()
    {
        
       
       if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);

        }
    }

   private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        Debug.Log(spawners.Length);

        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
           
            Debug.Log(isCloseEnough);

            if (isCloseEnough)
            {
               myLaneSpawner = spawner;
                Debug.Log( myLaneSpawner.name) ;

            }
        }
    }

        private bool IsAttackerInLane()
        {
            if (myLaneSpawner.transform.childCount <= 0)
            {
                return false;
           }
            else
            {
               return true;
            }
        }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
