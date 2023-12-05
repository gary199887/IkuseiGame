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
    const int maxPower = 999;
    const int minIntelligent = 0;
    const int maxIntelligent = 999;
    const int minMental = 0;
    const int maxMental = 999;

    // �J�����Ȃ����
    int friendly;       // �D���x�i�����l0, ����A����(�}�C�i�X)�����߂�j

    const int minFriendly = -50;
    const int maxFriendly = 100;


    public Chara (){        // contructor �L�����N�^�̏����l�����߂�
        hp = 100; 
        power = 50; 
        intelligent = 50; 
        mental = 50; 
        friendly = 0;
    }
    public Chara(int hp, int power, int intelligent, int mental, int friendly)
    {
        this.hp = hp;
        this.power = power;
        this.intelligent = intelligent;
        this.mental = mental;
        this.friendly = friendly;
    }

    public Chara(Chara copyFrom) {
        hp = copyFrom.hp;
        power = copyFrom.power;
        intelligent= copyFrom.intelligent;
        mental= copyFrom.mental;
        friendly= copyFrom.friendly;
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
        string showingStatus = $"HP\n{hp}\n\n�ؗ�\n{power}\n\n�m��\n{intelligent}\n\n�����^��\n{mental}\n";
        return showingStatus;
    }

    public int getHp() {
        return hp;
    }
    public int getPower() {
        return power;
    }
    public int getIntelligent() {
        return intelligent;
    }

    public int getMental() {
        return mental;
    }

    public int getFriendly() {
        return friendly;
    }

    public int getMaxPower() {
        return maxPower;
    }

    public int getMaxIntelligent(){
        return maxIntelligent;
    }

    public int getMaxMental(){
        return maxMental;
    }

    public int getMaxFriendly(){
        return maxFriendly;
    }
}