using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private AudioManager audioManager;
    public Camera _camera;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _collider;
    private int bullets = 10;
    public TextMeshProUGUI bulletCount;
    private AudioSource _audioSource;
    private GameManager _gameManager;
    public GameObject spreader;

    public List<Sprite> skins;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
        _collider.enabled = false;
        _audioSource = GetComponent<AudioSource>();
        audioManager = FindObjectOfType<AudioManager>();
        _gameManager = FindObjectOfType<GameManager>();

        _spriteRenderer.sprite = skins[PlayerPrefs.GetInt("skin", 0)];
        spreader.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_camera.ScreenToWorldPoint(Input.mousePosition).x, _camera.ScreenToWorldPoint(Input.mousePosition).y, 0);
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("Shoot");
        }

        if (Input.GetMouseButtonDown(1))
            if (bullets < 10)
            {
                bullets++;
                _audioSource.Play();
            }
        
        bulletCount.text = bullets.ToString();

    }

    IEnumerator Shoot()
    {
        if (_gameManager.isPaused) yield break;
        if (bullets > 0)
        {
            _spriteRenderer.color = Color.green;
            _collider.enabled = true;
            spreader.SetActive(true);
            audioManager.PlayShoot();
            yield return new WaitForSeconds(0.1f);
            _collider.enabled = false;
            spreader.SetActive(false);
            _spriteRenderer.color = Color.yellow;
            bullets--;
        }
        else
        {
            _spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            _spriteRenderer.color = Color.yellow;
        }

    }
    
    
}
