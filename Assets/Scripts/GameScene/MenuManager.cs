using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject buttons;
    [SerializeField]
    GameObject menuBer;
    [SerializeField] DialogManager dialogManager;
    private void Start()
    {
        menuBer.SetActive(false);
    }
    public void MenuStart()
    {
        buttons.SetActive(false);
        menuBer.SetActive(true);
    }
   public void MenuCancel()
    {
        menuBer.SetActive(false);
        buttons.SetActive(true);
    }

    public void BackTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void BackDeskTop()
    {
#if UNITY_EDITOR                                        // environment check
        UnityEditor.EditorApplication.isPlaying = false;    // end game
#else
                Application.Quit();                                 // end game
#endif
    }

    
}