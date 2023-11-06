using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))       // マウス左ボタンクリック
        {
            Vector3 mousePos = Input.mousePosition;
            Debug.Log(mousePos);                // マウス位置(Vec3)をlogにプリント
            

            GameObject clickedGameObject = null;    // クリックしたGameObject (initialized as null)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                //  クリックしたGameObjectを代入
                clickedGameObject = hit2d.transform.gameObject;
            }

            Debug.Log(clickedGameObject);   // print out in log
        }
    }
}
