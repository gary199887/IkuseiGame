using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHintManager : MonoBehaviour
{
    [SerializeField] Text[] lvHint;         // 各行動レベル
    [SerializeField] Text[] successHint;    // 各行動成功率

    // 行動レベルアップをUIに反映
    public void lvUpInUI(int id, int lv) {
        lvHint[id].text = $"行動Lv {lv}";
    }

    // 行動成功率をUIに反映      今の成功率：基礎値20 + キャラHP + 行動レベル(1~5) * 5
    public void successChangeInUI(int hp, Action[] actions) {
        for (int i = 0; i < actions.Length; ++i) {
            successHint[i].text = $"成功率：{Mathf.Clamp(20 + hp + actions[i].getLv() * 5, 0, 100)}%";
        }
    }
}
