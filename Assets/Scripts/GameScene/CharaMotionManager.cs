using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharaMotionManager : MonoBehaviour
{
    [SerializeField] GameObject charaImg;
    int times = 0;
    Vector2 position;       // キャラ画像の元位置
    Vector2 target;         // 移動したい目標位置
    const float distance = 0.5f;    // 移動したい距離
    const float speed = 20.0f;      // 移動速度
    bool moveX;                     // 移動するのはX軸か（falseならy軸（縦））


    void Start()
    {
        position = charaImg.transform.position;
    }
    void Update()
    {
        if (times != 0) {
            if (moveX)  // 横
            {
                int rightOrLeft = times % 2;
                if (times > 4)
                {
                    charaImg.transform.position = position;
                    times = 0;
                    return;
                }
                switch (rightOrLeft)
                {
                    case 0:
                        target = position + Vector2.left * distance;
                        if (charaImg.transform.position.x > target.x)
                            charaImg.transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
                        else
                            times++;
                        break;
                    case 1:
                        target = position + Vector2.right * distance;
                        if (charaImg.transform.position.x < target.x)
                            charaImg.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
                        else
                            times++;
                        break;
                }
            }
            else {      // 縦
                int upOrDown = times % 2;
                if (times > 4)
                {
                    charaImg.transform.position = position;
                    times = 0;
                    return;
                }
                switch (upOrDown)
                {
                    case 0:
                        target = position + Vector2.down * distance;
                        if (charaImg.transform.position.y > target.y)
                            charaImg.transform.Translate(new Vector2(0, -speed * Time.deltaTime));
                        else
                            times++;
                        break;
                    case 1:
                        target = position + Vector2.up * distance;
                        if (charaImg.transform.position.y < target.y)
                            charaImg.transform.Translate(new Vector2(0, speed * Time.deltaTime));
                        else
                            times++;
                        break;
                }
            }
        }
    }

    public void moveChara() {
        target = position + Vector2.right * distance;
        moveX = Random.Range(0,2) == 0;
        times++;
    }
}
