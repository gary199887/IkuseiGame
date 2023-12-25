using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MyButton button;

    private void Start()
    {
        button = null;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))       // マウス左ボタンクリック
        {
           
            Vector3 mousePos = Input.mousePosition;
            //Debug.Log(mousePos);                // マウス位置(Vec3)をlogにプリント
            

            GameObject clickedGameObject = null;    // クリックしたGameObject (initialized as null)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                //  クリックしたGameObjectを代入
                clickedGameObject = hit2d.transform.gameObject;
            }

            if (clickedGameObject != null && clickedGameObject.CompareTag("ButtonInTitleScene"))
            {
                    button = clickedGameObject.GetComponent<MyButton>();
                    Invoke("doButtonFunction", 0.15f);

                    TitleDirector.buttonClicked = true;

            }
            
           //Debug.Log(clickedGameObject);   // print out in log
        }
    }

    void doButtonFunction() {
        button.onClicked();
    }
}
