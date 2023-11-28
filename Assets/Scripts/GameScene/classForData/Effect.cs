[System.Serializable]
public class Effect
{
    public int time;
    // �v���C���ɊJ��������
    public int hp;             // HP
    public int power;          // �ؗ�
    public int intelligent;    // �m��
    public int mental;         // �����^��

    // �J�����Ȃ����
    public int friendly;       // �D���x

    string[] parameterName = { "HP", "�ؗ�", "�m��", "�����^��", "�D���x" };       // �p�����[�^��
    public Effect(int time = 0,int hp = 0, int power = 0, int intelligent = 0, int mental = 0, int friendly = 0) {
        this.time = time;
        this.hp = hp;
        this.power = power;
        this.intelligent = intelligent;
        this.mental = mental;
        this.friendly = friendly;
    }

    public Effect(Effect copyFrom) {
        this.time = copyFrom.time;
        this.hp = copyFrom.hp;
        this.power = copyFrom.power;
        this.intelligent = copyFrom.intelligent;
        this.mental = copyFrom.mental;
        this.friendly = copyFrom.friendly;
    }
    string getChangedMsg(int mode){  // �ϓ��������b�Z�[�W���擾(private)    mode��0�̏ꍇ�͏オ�������l �A 0�ȊO�̏ꍇ�͉����������l�̔���
        int hasChangedTimes = 0;        // �ϓ�������(�h�Ɓh�����邽��)
        string returnString = "";       // �Ԃ�������(����)
        int[] parameter = { hp, power, intelligent, mental, friendly };     // �e������e�p�����[�^

        for (int i = 0; i < parameterName.Length; ++i)
        {
            if (mode == 0 ? parameter[i] > 0 : parameter[i] < 0)
            {
                if (hasChangedTimes != 0)
                    // �O�ɕω��������l������Ɓg�Ɓh������
                    returnString += "��";
                // �ω������p�����[�^��������
                returnString += parameterName[i];
                // �ω������񐔂����Z
                hasChangedTimes++;
            }
        }

        if (hasChangedTimes != 0)
            returnString += mode == 0 ? "���オ����" :"����������";
        else
            returnString += mode == 0 ? "�����オ��Ȃ�����" : "����������Ȃ�����";
        return returnString;
    }

    public string getPlusMsg() {     // �㏸�����p�����[�^�ύX���b�Z�[�W
        return getChangedMsg(0);
    }

    public string getMinusMsg()
    {     // ���������p�����[�^�ύX���b�Z�[�W
        return getChangedMsg(1);
    }

    // ��Effect�N���X�����Z���邽�߂̃��\�b�h�@
    public Effect plusEffect(Effect addEffect) {
        Effect result = new Effect(this);
        result.time += addEffect.time;
        result.hp += addEffect.hp;
        result.power += addEffect.power;
        result.intelligent += addEffect.intelligent;
        result.mental += addEffect.mental;
        result.friendly += addEffect.friendly;

        return result;
    }
}
   
