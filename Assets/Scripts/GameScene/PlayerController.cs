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
        if (Input.GetButtonDown("Fire1"))       // �}�E�X���{�^���N���b�N
        {
           
            Vector3 mousePos = Input.mousePosition;
            //Debug.Log(mousePos);                // �}�E�X�ʒu(Vec3)��log�Ƀv�����g
            

            GameObject clickedGameObject = null;    // �N���b�N����GameObject (initialized as null)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                //  �N���b�N����GameObject����
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
