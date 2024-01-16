using UnityEngine;

public class FixedEventManager : MonoBehaviour
{
    public static FixedEventList fixedEventList;        // �Œ�C�x���g���X�g�iGameDirector�X�N���v�g���ɐݒ肳���j
    [SerializeField] DialogManager dialogManager;       // �_�C�A���O�}�l�[�W���[�i�_�C�A���O�\���p�j
    [SerializeField] ActionSelector actionSelector;     // �A�N�V�����Z���N�^�[�ieffect����p�j
    [SerializeField] Sprite[] sprites;                  // �摜�f�[�^�i�f�[�^�w��p�j
    [SerializeField] SpriteRenderer eventImg;           // �摜�f�[�^����p
    public static int route;                            // ���[�g�i�����l-1�A���ڂ̌Œ�C�x���g�Ń��[�g����(0 ~ 2)�j
    int thisTime;
    public static int currentSpriteId = -1;
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
        thisTime = currentDay / 7;
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
                doFixedEvent(fixedEventList.fixedEvents[15]);
                route = 3;
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
                case 3:     // �ϓ����[�g
                    if (chara.getPower() == chara.getIntelligent() && chara.getPower() == chara.getMental())    // �ϓ�
                        doFixedEvent(fixedEventList.fixedEvents[15]);
                    else�@�@�@// ���l��������ĂȂ�
                    {
                        doFixedEvent(fixedEventList.fixedEvents[16]);
                        route = 4;
                    }
                    break;
            }
        }
        else
        { // �O�T�ڂ̌Œ�C�x���g
            int friendlyUpLine = 50;
            if (route < 3)
                if (chara.getFriendly() >= friendlyUpLine)
                    doFixedEvent(fixedEventList.fixedEvents[9 + route * 2]);
                else
                    doFixedEvent(fixedEventList.fixedEvents[10 + route * 2]);
            else
            {
                if (route == 3)
                {
                    if (chara.getPower() == chara.getIntelligent() && chara.getPower() == chara.getMental())
                        doFixedEvent(fixedEventList.fixedEvents[17]);
                }
                else
                {
                    if (chara.getPower() == chara.getIntelligent() && chara.getPower() == chara.getMental())
                        doFixedEvent(fixedEventList.fixedEvents[15]);
                    else
                        doFixedEvent(fixedEventList.fixedEvents[16]);
                }
            }

        }
    }

    void doFixedEvent(FixedEvent fixedEvent)
    {
        fixedEvent.happened = true;
        dialogManager.showDialog(CommonFunctions.stringAddToLast(fixedEvent.msg, "4���ԋx�e����..."));    // �Œ�C�x���g���b�Z�[�W�\��(�Ō��4���ԋx�e�����ƕ����ǉ�)
        if (fixedEvent.id == 16)
        {
            Chara chara = new Chara(GameDirector.chara);
            int statusAverage = (chara.getPower() + chara.getIntelligent() + chara.getMental()) / 3;
            fixedEvent.effect = Effect.statusToTargetChara(chara, new Chara(0, statusAverage, statusAverage, statusAverage, 0));
        }
        actionSelector.effect = fixedEvent.effect.plusEffect(new Effect(4, 20));    // �C�x���g�̉e���ɓ��t�o�߂̉e����ǉ��i4���Ԍo�߁AHP�{20�j
        if (fixedEvent.id < 15)
        {
            showEventImg(sprites[fixedEvent.id]);
            currentSpriteId = fixedEvent.id;
        }
        else
        {
            switch (thisTime)
            {
                case 1:
                    showEventImg(sprites[2]);
                    currentSpriteId = 2;
                    break;
                case 2:
                    showEventImg(sprites[8]);
                    currentSpriteId = 8;
                    break;
                case 3:
                    showEventImg(sprites[14]);
                    currentSpriteId = 14;
                    break;
            }
        }

    }
    public void loadEventImg(int day,int route) 
    {
        //��ɂȂ����
        if (day >= 7&&day<=14)
        {
            switch (route)
            {
                case 0:
                    showEventImg(sprites[0]);
                    break;
                case 1:
                    showEventImg(sprites[1]);
                    break;
                case 2:
                    showEventImg(sprites[2]);
                    break;
                case 3:
                    showEventImg(sprites[2]);
                    break;
            }
        }
        //�ڂ݂ɂȂ����
        else if(day >= 15 && day <= 21)
        {
            switch (route)
            {
                case 0:
                    showEventImg(sprites[3]);
                    break;
                case 1:
                    showEventImg(sprites[5]);
                    break;
                case 2:
                    showEventImg(sprites[7]);
                    break;
                case 3:
                    showEventImg(sprites[7]);
                    break;
            }
       }
        
        
        //�ԂɂȂ����
        else if(day >= 22)
        {
            switch (route)
            {

                case 0:
                    showEventImg(sprites[9]);
                    break;
                case 1:
                    showEventImg(sprites[11]);
                    break;
                case 2:
                    showEventImg(sprites[13]);
                    break;
                case 3:
                    showEventImg(sprites[13]);
                    break;
            }
        }


    }
    public void showEventImg(Sprite img)
    {
        eventImg.sprite = img;
        eventImg.gameObject.SetActive(true);
    }

    public void changeSprite(int id) {
        currentSpriteId = id;
        eventImg.sprite = sprites[id];
        eventImg.gameObject.SetActive(true);
    }

    public void hideEventImg()
    {
        eventImg.gameObject.SetActive(false);
    }

}
