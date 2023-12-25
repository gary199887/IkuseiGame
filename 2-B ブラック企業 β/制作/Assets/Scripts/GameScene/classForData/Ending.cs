using System;
using System.Collections.Generic;

[System.Serializable]
public class Ending
{
    public int id;
    public string name;
    public string[] description;
    public bool cleared;
    public string hint;

    public Ending(int id = 0, string name = "��̐A��", string[] description = null, bool cleared = false, string hint = "") {
        this.id = id;
        this.name = name;
        this.description = description;
        if(this.description == null)
            this.description = new string[]{"��̕�����Ȃ����\�ȐA���ł���", "�G�H", "���Ԍn�s���~�b�h�̒��_���N�Ղ���", "�₪�Đl�ނ����H�אs�������̂ł�����"};
        this.cleared = cleared;
    }
}

[System.Serializable]
public class EndingList {
    public List<Ending> endings;

    public EndingList() {
        endings = new List<Ending>();
    }
}
