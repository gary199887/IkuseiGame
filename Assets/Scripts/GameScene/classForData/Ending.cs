public class Ending
{
    public int id;
    public string name;
    public string[] description;

    public Ending(int id = 0, string name = "��̐A��", string[] description = null) {
        this.id = id;
        this.name = name;
        this.description = description;
        if(this.description == null)
            this.description = new string[]{"��̕�����Ȃ����\�ȐA���ł���", "�G�H", "���Ԍn�s���~�b�h�̒��_���N�Ղ���", "�₪�Đl�ނ����H�אs�������̂ł�����"};
    }
}
