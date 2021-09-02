using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerF : MonoBehaviour
{
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(2, 15));
        Instantiate(enemies[Random.Range(0, enemies.Length - 1)], new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        StartCoroutine("Spawn");
    }
}
