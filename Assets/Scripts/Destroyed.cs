using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestroyAfterSeconds");
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
