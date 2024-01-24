using UnityEngine;

public class CharaMotionManager : MonoBehaviour
{
    [SerializeField] GameObject charaImg;   // キャラ画像
    int times = 0;
    Vector2 position;       // キャラ画像の元位置
    Vector2 target;         // 移動したい目標位置
    const float distance = 0.5f;    // 移動したい距離
    const float speed = 20.0f;      // 移動速度
    Vector2 direction;          // 移動方向ベクトル


    void Start()
    {
        position = charaImg.transform.position;     // キャラ画像の位置を代入
    }
    void Update()
    {
        if (times != 0){
            if (times > 4)  // 停止、元の位置に戻す
            {
                charaImg.transform.position = position;
                times = 0;
                return;
            }

            int plusOrMinus = times % 2;        // 移動方向の正負方向かtimesから判定
            switch (plusOrMinus)
            {
                case 0:     // 正
                    target = position + direction * distance;
                    if (charaImg.transform.position.x <= target.x)      // xの値から動き続くかを判定
                        charaImg.transform.Translate(direction * speed * Time.deltaTime);
                    else    // 反対方向に変更or停止
                        times++;
                    break;
                case 1:     // 負(反対方向)
                    target = position - direction * distance;
                    if (charaImg.transform.position.x >= target.x)
                        charaImg.transform.Translate(-direction * speed * Time.deltaTime);
                    else
                        times++;
                    break;
            }
        }
    }

    public void moveChara()
    {
        float angle = Random.Range(-89, 90) * Mathf.Deg2Rad;    // 角度を-89~89からランダム（ラジアンに変換）　　角度の指定はx軸が必ず正の値(>0)の角度を指定
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized; // モーションの方向ベクトルに代入
        times++;    // 動きを始める
    }
}
