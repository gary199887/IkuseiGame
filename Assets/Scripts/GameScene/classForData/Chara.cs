using UnityEditor;

public class Chara
{
    // �v���C���ɊJ�������� ����0, ����܂����߂ĂȂ�
    int hp;             // HP
    int power;          // �ؗ�
    int intelligent;    // �m��
    int mental;         // �����^��

    // �J�����Ȃ����
    public int friendly;       // �D���x�i�����l0, ����A����(�}�C�i�X)�����߂�j

    public Chara (){        // contructor �L�����N�^�̏����l�����߂�
        hp = 100; 
        power = 0; 
        intelligent = 0; 
        mental = 80; 
        friendly = 0;
    }

    public void addEffect(Effect effect) {      // �e�������X�e�[�^�X�̉��Z
        hp += effect.hp;
        power += effect.power;
        intelligent += effect.intelligent;
        mental += effect.mental;
        friendly += effect.friendly;
    }

    public string getShowingStatus() {          // �X�e�[�^�X�ύX�p������
        string showingStatus = $"HP:\n{hp}\n\n�ؗ�\n{power}\n\n�m��\n{intelligent}\n\n�����^��\n{mental}\n";
        return showingStatus;
    }
}