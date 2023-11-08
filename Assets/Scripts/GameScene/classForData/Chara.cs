using System;
using UnityEditor;

public class Chara
{
    // �v���C���ɊJ�������� ����0, ����܂����߂ĂȂ�
    int hp;             // HP
    int power;          // �ؗ�
    int intelligent;    // �m��
    int mental;         // �����^��

    const int minHP = 0;
    const int maxHP = 100;
    const int minPower = 0;
    const int maxPower = 100;
    const int minIntelligent = 0;
    const int maxIntelligent = 100;
    const int minMental = 0;
    const int maxMental = 100;

    // �J�����Ȃ����
    int friendly;       // �D���x�i�����l0, ����A����(�}�C�i�X)�����߂�j

    const int minFriendly = 0;
    const int maxFriendly = 100;


    public Chara (){        // contructor �L�����N�^�̏����l�����߂�
        hp = 100; 
        power = 0; 
        intelligent = 0; 
        mental = 80; 
        friendly = 0;
    }

    public void doEffect(Effect effect) {      // �e�������X�e�[�^�X�̉��Z
        // �ύX�O�̐��l��ۑ�
        int beforeHP = hp;
        // ���l���Z�A�ŏ��l�ƍő�l�͈͓̔��ɐ���
        hp = Math.Clamp(hp + effect.hp, minHP, maxHP);
        // ���ەϓ��������l��effect�ɑ��(�������ύX���b�Z�[�W���擾���邽��)
        effect.hp = hp - beforeHP;

        // �ȉ����l
        
        int beforePower = power;
        power = Math.Clamp(power + effect.power, minPower, maxPower);
        effect.power = power - beforePower;

        int beforeIntelligent = intelligent;
        intelligent = Math.Clamp(intelligent + effect.intelligent, minIntelligent, maxIntelligent);
        effect.intelligent = intelligent - beforeIntelligent;
        

        int beforeMental = mental;
        mental = Math.Clamp(mental + effect.mental, minMental, maxMental);
        effect.mental = mental - beforeMental;

        int beforeFriendly = friendly;
        friendly = Math.Clamp(friendly + effect.friendly, minFriendly, maxFriendly);
        effect.friendly = friendly - beforeFriendly;
    }

    public string getShowingStatus() {          // �X�e�[�^�X�ύX�p������
        string showingStatus = $"HP:\n{hp}\n\n�ؗ�\n{power}\n\n�m��\n{intelligent}\n\n�����^��\n{mental}\n";
        return showingStatus;
    }
}