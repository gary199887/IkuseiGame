using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    [SerializeField] Text[] lvHint;         // 各行動レベル
    [SerializeField] Text[] successHint;    // 各行動成功率
    [SerializeField] Text[] effectHint;     // 影響効果量表示用テキストオブジェクト　0:hp   1:power  2:intelligent  3:mental

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

    // 影響の各数値をUIに表示
    public void showEffectHint(Effect effect) {
        // 影響クラスのパラメータ別で判定(0の場合は非表示のまま)
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

    // 影響テキストUIを非表示にする
    public void closeEffectHint() {
        foreach(var hintText in effectHint)
            hintText.gameObject.SetActive(false);
    }

    // 正負値を色分けしてテキストに代入
    void changeEffectText(Text text, int effectValue) {
        // 数値がプラスである場合
        if (effectValue > 0)
        {
            text.color = Color.green + new Color(0, -0.3f, 0, 0);   // green(Color(0, 1, 0, 0))だと明るすぎるのでちょっと暗くなるよう調整
            text.text = $"+{effectValue}";
        }
        // 数値がマイナスである場合
        else if (effectValue < 0) {
            text.color = Color.red;
            text.text = $"{effectValue}";
        }
    }

    
}
