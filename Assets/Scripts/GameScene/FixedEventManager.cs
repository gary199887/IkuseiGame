using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FixedEventManager : MonoBehaviour
{
    public static FixedEventList fixedEventList;        // �Œ�C�x���g���X�g�iGameDirector�X�N���v�g���ɐݒ肳���j
    [SerializeField] DialogManager dialogManager;       // �_�C�A���O�}�l�[�W���[�i�_�C�A���O�\���p�j
    [SerializeField] ActionSelector actionSelector;     // �A�N�V�����Z���N�^�[�ieffect����p�j
    [SerializeField] Sprite[] sprites;                  // �摜�f�[�^�i�f�[�^�w��p�j
    [SerializeField] SpriteRenderer eventImg;           // �摜�f�[�^����p
    public static int route;                            // ���[�g�i�����l-1�A���ڂ̌Œ�C�x���g�Ń��[�g����(0 ~ 2)�j
    void Start()
    {
        route = -1;
    }
    public static void setFixedEvent(FixedEventList loadedList)
    {
        fixedEventList = loadedList;
    }

    public void occurFixedEvent(int currentDay)
    {
        // ���T�ڂ̌Œ�C�x���g���v�Z
        int thisTime = currentDay / 7;
        Chara chara = new Chara(GameDirector.chara);
        // 7���ڂ���8���ڂɐi�ގ��ɔ���
        if (thisTime == 1)
        {
            // A(�ؗ�)���[�g
            if (chara.getPower() >= chara.getIntelligent() && chara.getPower() > chara.getMental())
            {
                //doFixedEvent(fixedEventList.fixedEvents.Find(a => a.id == 0));
                doFixedEvent(fixedEventList.fixedEvents[0]);
                route = 0;
            }

            // B(�m��)���[�g 
            else if (chara.getIntelligent() > chara.getPower() && chara.getIntelligent() >= chara.getMental())
            {
                doFixedEvent(fixedEventList.fixedEvents[1]);
                route = 1;
            }

            // C(�����^��)���[�g
            else if (chara.getMental() >= chara.getPower() && chara.getMental() > chara.getIntelligent())
            {
                doFixedEvent(fixedEventList.fixedEvents[2]);
                route = 2;
            }
            else
            { // all equal (���i�K�ł͂ЂƂ܂��ؗ̓��[�g�ɐi��)
                doFixedEvent(fixedEventList.fixedEvents[0]);
                route = 0;
            }
        }
        else if (thisTime == 2)
        {
            int upLine = 200; // �C�x���g�����߂�e���l�̃��C�� 
            switch (route)
            {
                case 0:     // �ؗ̓��[�g
                    if (chara.getPower() >= upLine)
                        doFixedEvent(fixedEventList.fixedEvents[3]);
                    else
                        doFixedEvent(fixedEventList.fixedEvents[4]);
                    break;
                case 1:     // �m�̓��[�g
                    if (chara.getIntelligent() >= upLine)
                        doFixedEvent(fixedEventList.fixedEvents[5]);
                    else
                        doFixedEvent(fixedEventList.fixedEvents[6]);
                    break;
                case 2:     // �����^�����[�g
                    if (chara.getMental() >= upLine)
                        doFixedEvent(fixedEventList.fixedEvents[7]);
                    else
                        doFixedEvent(fixedEventList.fixedEvents[8]);
                    break;
            }
        }
        else
        { // �O�T�ڂ̌Œ�C�x���g������
            int friendlyUpLine = 50;
            if (chara.getFriendly() >= friendlyUpLine)
                doFixedEvent(fixedEventList.fixedEvents[9 + route * 2]);
            else
                doFixedEvent(fixedEventList.fixedEvents[10 + route * 2]);
        }
    }

    void doFixedEvent(FixedEvent fixedEvent)
    {
        fixedEvent.happened = true;
        dialogManager.showDialog(stringAddToLast(fixedEvent.msg, "4���ԋx�e����..."));
        actionSelector.effect = fixedEvent.effect.plusEffect(new Effect(4, 20));    // �C�x���g�̉e���ɓ��t�o�߂̉e����ǉ�
        showEventImg(sprites[fixedEvent.id]);
    }

    public void showEventImg(Sprite img)
    {
        eventImg.sprite = img;
        eventImg.gameObject.SetActive(true);
    }

    public void hideEventImg()
    {
        eventImg.gameObject.SetActive(false);
    }

    public string[] stringAddToLast(string[] originalString, string addString)
    {
        List<string> result = new List<string>(originalString.ToList<string>());
        result.Add(addString);
        return result.ToArray();
    }
}
