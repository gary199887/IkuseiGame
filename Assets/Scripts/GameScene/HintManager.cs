using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    [SerializeField] Text[] lvHint;         // �e�s�����x��
    [SerializeField] Text[] successHint;    // �e�s��������
    [SerializeField] Text[] effectHint;     // �e�����ʗʕ\���p�e�L�X�g�I�u�W�F�N�g�@0:hp   1:power  2:intelligent  3:mental

    // �s�����x���A�b�v��UI�ɔ��f
    public void lvUpInUI(int id, int lv) {
        lvHint[id].text = $"�s��Lv {lv}";
    }

    // �s����������UI�ɔ��f      ���̐������F��b�l20 + �L����HP + �s�����x��(1~5) * 5
    public void successChangeInUI(int hp, Action[] actions) {
        for (int i = 0; i < actions.Length; ++i) {
            successHint[i].text = $"�������F{Mathf.Clamp(20 + hp + actions[i].getLv() * 5, 0, 100)}%";
        }
    }

    // �e���̊e���l��UI�ɕ\��
    public void showEffectHint(Effect effect) {
        // �e���N���X�̃p�����[�^�ʂŔ���(0�̏ꍇ�͔�\���̂܂�)
        if (effect.hp != 0) {
            effectHint[0].gameObject.SetActive(true);
            changeEffectText(effectHint[0], effect.hp);
        }
        if (effect.power != 0)
        {
            effectHint[1].gameObject.SetActive(true);
            changeEffectText(effectHint[1], effect.power);
        }
        if (effect.intelligent != 0)
        {
            effectHint[2].gameObject.SetActive(true);
            changeEffectText(effectHint[2], effect.intelligent);
        }
        if (effect.mental != 0)
        {
            effectHint[3].gameObject.SetActive(true);
            changeEffectText(effectHint[3], effect.mental);
        }
    }

    // �e���e�L�X�gUI���\���ɂ���
    public void closeEffectHint() {
        foreach(var hintText in effectHint)
            hintText.gameObject.SetActive(false);
    }

    // �����l��F�������ăe�L�X�g�ɑ��
    void changeEffectText(Text text, int effectValue) {
        // ���l���v���X�ł���ꍇ
        if (effectValue > 0)
        {
            text.color = Color.green + new Color(0, -0.3f, 0, 0);   // green(Color(0, 1, 0, 0))���Ɩ��邷����̂ł�����ƈÂ��Ȃ�悤����
            text.text = $"+{effectValue}";
        }
        // ���l���}�C�i�X�ł���ꍇ
        else if (effectValue < 0) {
            text.color = Color.red;
            text.text = $"{effectValue}";
        }
    }

    
}
