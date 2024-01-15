using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadManager : MonoBehaviour
{
    public static LoadManager instance;
    SaveData saveData;

    void Awake()
    {
        CheckInstance();
    }

    void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void load()
    {
        if (SceneManager.GetActiveScene().name!="GameScene") return;
        saveData=new SaveData();
        saveData= SaveIO.DataLoad();
        if (saveData != null)
        {
            //�L����
            GameDirector.chara.load(saveData.status);
            //�A�N�V����
            ActionSelector.actions = saveData.actions.ToArray();
            //�����Ǝ���
            GameDirector.currentDay = saveData.nowDay;
            GameDirector.currentHour = saveData.nowHour;

            //�琬���[�g
            FixedEventManager.route = saveData.route;
            
             //�L�����N�^�[�̉摜
                //FixedEventManager�ɂ���L�����摜�������ւ��Ă���
            //�����_���C�x���g�̔����ςݍ폜
                //RandomEventManager�̃����_���C�x���g�̃��X�g����A�Z�[�u��̃��X�g���Q�Ƃ��Ė����Ȃ��Ă�����̂������@0~7�̂�������
            
        }
    }
    
}
