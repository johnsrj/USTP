using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
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
    }

    private void Die()
    {
        _audioManager.Play("EnemyBreak");
        gameManager.AddScore(score);
        Vector2 pos = new Vector2(transform.position.x - 0.8f, transform.position.y); 
        Instantiate(broken, pos, Quaternion.identity);
        Destroy(gameObject);
    }
}
