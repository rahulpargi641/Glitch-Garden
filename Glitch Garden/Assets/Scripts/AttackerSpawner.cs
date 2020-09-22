using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker attackerPrefab;
    

    bool spawn = true;

    [SerializeField ]float minSpawnDelay = 1f;
    [SerializeField]float maxSpawnDelay = 5f;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            spawnAttacker();
        }
    }
    
    private void spawnAttacker()
    {
       Attacker newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation) as Attacker;
       newAttacker.transform.parent = transform;
        
       // Debug.Log( newAttacker.transform.position);
        

       
       
    }

 
}
