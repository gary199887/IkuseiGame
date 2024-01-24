using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMouseOver : MonoBehaviour
{
    [SerializeField]
    Sprite isOver;
    [SerializeField]
    Sprite isExit;

    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    private void OnMouseOver()
    {
        spriteRenderer.sprite = isOver;
    }

    private void OnMouseExit()
    {
        spriteRenderer.sprite = isExit;
    }
}
