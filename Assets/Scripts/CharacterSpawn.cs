using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    public GameObject[] characters_up;
    public GameObject[] characters_down;

    public Transform[] spawnPoints_up;
    public Transform[] spawnPoints_down;

    public float curSpawnDelay;
    public float maxSpawnDelay;

    private void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnCharacter();
            curSpawnDelay = 0;
        }
    }

    void SpawnCharacter()
    {
        int ranNumber_up = Random.Range(0, 5);
        int ranNumber_down = Random.Range(0, 3);
        int ranPoint = Random.Range(0, 2);

        Instantiate(characters_up[ranNumber_up], spawnPoints_up[ranPoint].position, spawnPoints_up[ranPoint].rotation);
        Instantiate(characters_down[ranNumber_down], spawnPoints_down[ranPoint].position, spawnPoints_down[ranPoint].rotation);
    }


}
