public class EndingManager
{
    // �G���f�B���O��񃊃X�g(��)�A��X�O���t�@�C���ɕۑ����邩��
    public static Ending[] endingList = { new Ending(1, "�V�˃T�{�e���N", new string[] { "IQ200�̃T�{�e���N�B","�������E�ɖ���y���邩���B" }, false) };
    public static Ending chooseEnding(Chara chara) {
        Ending result = new Ending();
        // ���̏����i���X�͒m��MAX�j ���łł͓���m�F�̂��߉��̐��l�Ńe�X�g���܂�
        if(chara.getIntelligent() >= 200)     // >= chara.getMaxIntelligent())
            result = endingList[0];
        result.cleared = true;
        return result;
    }
}
