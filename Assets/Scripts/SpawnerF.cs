using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerF : MonoBehaviour
{
    private GameManager gm;
    public GameObject[] enemies;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        if (gm.Score < 1000)
        {
            yield return new WaitForSeconds(Random.Range(1, 15)); 
        }
        else if (gm.Score < 5000)
        {
            yield return new WaitForSeconds(Random.Range(1, 12));
        }
        else if (gm.Score < 10000)
        {
            yield return new WaitForSeconds(Random.Range(1, 8));
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
        
        Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        StartCoroutine("Spawn");
    }
}
