using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private GameManager gameManager;
    public float Speed;
    public int score;
    private AudioManager _audioManager;
    public GameObject broken;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * (Speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Die();
        }
        else if(other.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }

    private void Die()
    {
        gameManager.LoseHeart();
        Vector2 pos = new Vector2(transform.position.x, transform.position.y); 
        Instantiate(broken, pos, Quaternion.Euler(0,0,-90));
        Destroy(gameObject);
    }
}
