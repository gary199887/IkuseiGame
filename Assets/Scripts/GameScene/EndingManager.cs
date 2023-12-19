public class EndingManager
{
    // �G���f�B���O��񃊃X�g(��)�A��X�O���t�@�C���ɕۑ����邩��
    public static EndingList endingList;
    public static Ending chooseEnding(Chara chara, Action[] actions)
    {
        Ending result = new Ending();
        // actions: 0:�������@1:�׋��@2:�b�������@3:�O�o 4:����@5:�����

        // �S�U��n
        // �ؗ�
        if (checkOnlyAction(actions, 0, true))
        {
            result = endingList.endings[12];
            result.cleared = true;
            return result;
        }
        // �m��
        if (checkOnlyAction(actions, 1, true))
        {
            result = endingList.endings[13];
            result.cleared = true;
            return result;
        }
        // �����^��
        if (checkOnlyAction(actions, 2, true))
        {
            result = endingList.endings[14];
            result.cleared = true;
            return result;
        }
        // ���o����
        if (checkOnlyAction(actions, 3, false))
        {
            result = endingList.endings[18];
            result.cleared = true;
            return result;
        }
        // ����
        if (checkOnlyAction(actions, 4, true))
        {
            if (chara.getHp() >= 50)    // HP����
            {
                result = endingList.endings[15];
                result.cleared = true;
                return result;
            }
            else    // HP�Ⴂ
            {
                result = endingList.endings[16];
                result.cleared = true;
                return result;
            }
        }

        // MAX�n
        // �SMAX
        if (chara.getMaxPower() == chara.getMaxPower() &&
            chara.getIntelligent() == chara.getMaxIntelligent() &&
            chara.getMental() == chara.getMaxMental())
        {
            result = endingList.endings[19];
            result.cleared = true;
            return result;
        }
        // �ؗ�MAX
        if (chara.getPower() == chara.getMaxPower())
        {
            result = endingList.endings[2];
            result.cleared = true;
            return result;
        }
        // �m��MAX
        if (chara.getIntelligent() == chara.getMaxIntelligent())
        {
            result = endingList.endings[5];
            result.cleared = true;
            return result;
        }
        // �����^��MAX
        if (chara.getMental() == chara.getMaxMental())
        {
            result = endingList.endings[8];
            result.cleared = true;
            return result;
        }
        // �D���xMAX
        if (chara.getFriendly() == chara.getMaxFriendly())
        {
            result = endingList.endings[9];
            result.cleared = true;
            return result;
        }

        // Min�n
        // HP min
        if (chara.getHp() == 0)
        {
            result = endingList.endings[17];
            result.cleared = true;
            return result;
        }
        // �D���xmin
        if (chara.getFriendly() == chara.getMinFriendly())
        {
            result = endingList.endings[10];
            result.cleared = true;
            return result;
        }

        // ����g
        // �S�X�e�[�^�X����
        if (chara.getPower() == chara.getIntelligent() && chara.getPower() == chara.getMental())
        {
            result = endingList.endings[11];
            result.cleared = true;
            return result;
        }

        // ��r�n
        // �ؗ�
        if (chara.getPower() >= chara.getIntelligent() && chara.getPower() >= chara.getMental())
        {
            if (chara.getFriendly() >= 50)      // �D���x����
            {
                result = endingList.endings[0];
                result.cleared = true;
                return result;
            }
            else
            {
                result = endingList.endings[1];
                result.cleared = true;
                return result;
            }
        }
        // �m��
        if (chara.getIntelligent() >= chara.getPower() && chara.getIntelligent() >= chara.getMental())
        {
            if (chara.getFriendly() >= 50)
            {
                result = endingList.endings[3];
                result.cleared = true;
                return result;
            }
            else
            {
                result = endingList.endings[4];
                result.cleared = true;
                return result;
            }
        }
        // �����^��
        if (chara.getMental() >= chara.getPower() && chara.getMental() >= chara.getPower())
        {
            if (chara.getFriendly() >= 50)
            {
                result = endingList.endings[6];
                result.cleared = true;
                return result;
            }
            else
            {
                result = endingList.endings[7];
                result.cleared = true;
                return result;
            }
        }

        return result;
    }

    // �G���f�B���O���X�g�̑��(GameDirector�̃t�@�C���ǂݍ��݂̕����Ɏ��s)
    public static void setEngindList(EndingList endings)
    {
        endingList = endings;
    }

    // �N���A�G���f�B���O�����O���t�@�C���ɕۑ�
    public static void saveEndingList()
    {
        EndingIO.saveEnding(endingList);
    }

    // �S�U��`�F�b�N�i�����OK���Ƃ��������t���j
    static bool checkOnlyAction(Action[] actions, int onlyActionId, bool ignoreWater)
    {
        bool result = true;
        // ����肪���e�Ȃ琅�����`�F�b�N���Ȃ�
        int checkUntil = ignoreWater ? actions.Length - 1 : actions.Length;
        for (int i = 0; i < checkUntil; ++i)
        {
            if (i == onlyActionId)  // �`�F�b�N������id��
                if (actions[i].times > 0) continue;
                else return false;  // ����肵�������ꍇ�ɑΉ����邽��
            if (actions[i].times > 0) return false;
        }
        return result;
    }
}
