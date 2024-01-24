using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadManager : MonoBehaviour
{
    SaveData saveData;
    [SerializeField] FixedEventManager fixedEventManager;
    [SerializeField] HintManager hintManager;
    public void load()
    {
        if (SceneManager.GetActiveScene().name!="GameScene") return;
        saveData=new SaveData();
        saveData= SaveIO.DataLoad();
        if (saveData != null)
        {
            //�L����
            GameDirector.chara = new Chara(saveData.status);
            //�A�N�V����
            ActionSelector.actions = saveData.actions.ToArray();
            for(int i = 0; i < 3; ++i)
                hintManager.lvUpInUI(i, saveData.actions[i].lv);

            //�����Ǝ���
            GameDirector.currentDay = saveData.nowDay;
            GameDirector.currentHour = saveData.nowHour;

            //�琬���[�g
            FixedEventManager.route = saveData.route;

            //�L�����N�^�[�̉摜
            //FixedEventManager�ɂ���L�����摜�������ւ��Ă���
            if(saveData.charaSpriteId != -1)
                fixedEventManager.changeSprite(saveData.charaSpriteId);

            //�����_���C�x���g�̔����ςݍ폜
            saveData.events.Sort((a, b) => {
                return a.id.CompareTo(b.id);
            });

           
            RandomEventManager.randomEvents.Sort((a, b) =>
            {
                return a.id.CompareTo(b.id);
            });

            //RandomEventManager�̃����_���C�x���g�̃��X�g����A�Z�[�u��̃��X�g���Q�Ƃ��Ė����Ȃ��Ă�����̂������@0~7�̂�������
            for (int i = 0; i < saveData.events.Count;) {
                if (saveData.events[i].id != RandomEventManager.randomEvents[i].id)
                {
                    RandomEventManager.randomEvents.RemoveAt(i);
                }
                else
                    ++i;
            }
               
            
        }
    }
    
}
