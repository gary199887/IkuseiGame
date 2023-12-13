using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] endingImages;
    [SerializeField] Sprite[] sprites;
    [SerializeField] TitleDirector titleDirector;
    Bounds imgBounds;
    EndingList endingList;
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
                endingImages[i].gameObject.tag = "ClearedEnding";
            }
            else {
                endingImages[i].sprite = sprites[sprites.Length - 1];
                endingImages[i].gameObject.transform.localScale = new Vector2(1, 1);
                endingImages[i].gameObject.tag = "Untagged";
            }
        }
    }

    float resizeSprite(Sprite sprite) {
        return imgBounds.size.x  / sprite.bounds.size.x; 
    }
}
