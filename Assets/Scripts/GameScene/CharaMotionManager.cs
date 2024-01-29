using UnityEngine;

public class CharaMotionManager : MonoBehaviour
{
    [SerializeField] GameObject charaImg;   // �L�����摜
    int times = 0;
    Vector2 position;       // �L�����摜�̌��ʒu
    Vector2 target;         // �ړ��������ڕW�ʒu
    const float distance = 0.5f;    // �ړ�����������
    const float speed = 20.0f;      // �ړ����x
    Vector2 direction;          // �ړ������x�N�g��


    void Start()
    {
        position = charaImg.transform.position;     // �L�����摜�̈ʒu����
    }
    void Update()
    {
        if (times != 0){
            if (times > 4)  // ��~�A���̈ʒu�ɖ߂�
            {
                charaImg.transform.position = position;
                times = 0;
                return;
            }

            int plusOrMinus = times % 2;        // �ړ������̐���������times���画��
            switch (plusOrMinus)
            {
                case 0:     // ��
                    target = position + direction * distance;
                    if (charaImg.transform.position.x <= target.x)      // x�̒l���瓮���������𔻒�
                        charaImg.transform.Translate(direction * speed * Time.deltaTime);
                    else    // ���Ε����ɕύXor��~
                        times++;
                    break;
                case 1:     // ��(���Ε���)
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
        float angle = Random.Range(-89, 90) * Mathf.Deg2Rad;    // �p�x��-89~89���烉���_���i���W�A���ɕϊ��j�@�@�p�x�̎w���x�����K�����̒l(>0)�̊p�x���w��
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized; // ���[�V�����̕����x�N�g���ɑ��
        times++;    // �������n�߂�
    }
}