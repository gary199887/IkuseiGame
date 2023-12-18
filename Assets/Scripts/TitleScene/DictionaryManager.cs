using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DictionaryManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] endingImages;
    [SerializeField] public Sprite[] sprites;
    [SerializeField] TitleDirector titleDirector;
    Bounds imgBounds;
    public EndingList endingList;
    // Start is called before the first frame update
    void Start()
    {
        imgBounds = sprites[sprites.Length - 1].bounds;
        endingList = EndingIO.loadEnding();
        for (int i = 0; i < endingList.endings.Count; ++i) {
            if (endingList.endings[i].cleared)
            {
                endingImages[i].sprite = sprites[i];
                float scale = resizeSprite(sprites[i]);
                endingImages[i].gameObject.transform.localScale = new Vector2(scale, scale);
                endingImages[i].gameObject.tag = "ButtonInTitleScene";
                endingImages[i].gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1 / scale, 1 / scale);
            }
            else {
                endingImages[i].sprite = sprites[sprites.Length - 1];
                endingImages[i].gameObject.transform.localScale = new Vector2(1, 1);
                endingImages[i].gameObject.tag = "Untagged";
                endingImages[i].gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
            }
        }
    }

    public float resizeSprite(Sprite sprite) {
        return imgBounds.size.x  / sprite.bounds.size.x; 
    }

    
}
