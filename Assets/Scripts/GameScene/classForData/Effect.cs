public class Effect
{
    // �v���C���ɊJ��������
    public int hp;             // HP
    public int power;          // �ؗ�
    public int intelligent;    // �m��
    public int mental;         // �����^��

    // �J�����Ȃ����
    public int friendly;       // �D���x

    public Effect(int hp = 0, int power = 0, int intelligent = 0, int mental = 0, int friendly = 0) {
        this.hp = hp;
        this.power = power;
        this.intelligent = intelligent;
        this.mental = mental;
        this.friendly = friendly;
    }

    public string toPlusString() {
        int hasPlusTimes = 0;
        int hasMinusTimes = 0;
        string returnString = "";
        string[] parameterName = {"HP", "�ؗ�", "�m��", "�����^��", "�D���x"};
        int[] parameter = {hp, power, intelligent, mental, friendly};

        for (int i = 0; i < parameterName.Length; ++i) {
            if (parameter[i] > 0)
            {
                if (hasPlusTimes != 0)
                {
                    returnString += "��";
                }
                returnString += parameterName[i];
                hasPlusTimes++;
            }
            else {
                hasMinusTimes++;
            }
        }

        if (hasPlusTimes != 0)
            returnString += "���オ����";
        else
            returnString += "�����オ��Ȃ�����";
        return returnString;
    }
}
   
