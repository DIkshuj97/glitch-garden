using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerArray;

    bool spawn = true;
    // Start is called before the first frame update

    //delay some time between spawning
    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    //cloning of attacker at certain position
    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerArray.Length);
        Spawn(attackerArray[attackerIndex]);
    }
    
    private void Spawn(Attacker myattacker)
    {
        Attacker newattacker = Instantiate(myattacker, transform.position, transform.rotation) as Attacker;
        newattacker.transform.parent = transform;
    }
}
