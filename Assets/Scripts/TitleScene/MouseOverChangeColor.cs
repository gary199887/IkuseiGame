using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverChangeColor : MonoBehaviour
{
    [SerializeField]
    Color isOver;
    [SerializeField]
    Color isExit;

    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        spriteRenderer.color = isOver;
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = isExit;
    }
}
