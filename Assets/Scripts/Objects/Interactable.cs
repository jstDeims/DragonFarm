using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    [SerializeField] private int level = 1;

    [SerializeField] private Sprite[] images;

    [SerializeField] private AudioClip detectedSound;

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private bool can_interact = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = detectedSound;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.4f;
        ImageSwitcher(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && can_interact) 
        {
            ChangeScene();
        }
    }

    private void ImageSwitcher(int imageIndex)
    {
        spriteRenderer.sprite = images[imageIndex];
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.pitch = Random.Range(0.7f, 1.3f);
            print(audioSource.pitch);
            audioSource.Play();
            ImageSwitcher(1);
            can_interact = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ImageSwitcher(0);
            can_interact = false;
        }
    }
}
