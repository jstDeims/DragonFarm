using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    [SerializeField] private int level = 1;

    public Sprite[] images;
    private SpriteRenderer spriteRenderer;

    private bool can_interact = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
