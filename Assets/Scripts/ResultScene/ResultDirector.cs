using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultDirector : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;
    [SerializeField] Sprite[] endingImages;
    [SerializeField] Image endingRenderer;
    public static Ending ending;
    // Start is called before the first frame update
    void Start()
    {
        endingRenderer.sprite = endingImages[ending.id];
    }

    public void showResultMsg() {
        List<string> endMsg = new List<string>();
        endMsg.Add($"{ending.name}�Ɉ�����I");
        endMsg.AddRange(ending.description.ToList<string>());
        endMsg.Add("�}�E�X�N���b�N�Ń^�C�g����ʂɖ߂�");
        dialogManager.showDialog(endMsg.ToArray());
    }

    public void toTitle() {
        SceneManager.LoadScene("TitleScene");
    }
}
