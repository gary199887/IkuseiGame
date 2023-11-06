using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))       // �}�E�X���{�^���N���b�N
        {
            Vector3 mousePos = Input.mousePosition;
            Debug.Log(mousePos);                // �}�E�X�ʒu(Vec3)��log�Ƀv�����g
            

            GameObject clickedGameObject = null;    // �N���b�N����GameObject (initialized as null)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                //  �N���b�N����GameObject����
                clickedGameObject = hit2d.transform.gameObject;
            }

            Debug.Log(clickedGameObject);   // print out in log
        }
    }
}
