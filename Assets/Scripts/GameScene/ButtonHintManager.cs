using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHintManager : MonoBehaviour
{
    [SerializeField] Text[] lvHint;         // �e�s�����x��
    [SerializeField] Text[] successHint;    // �e�s��������

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
}
