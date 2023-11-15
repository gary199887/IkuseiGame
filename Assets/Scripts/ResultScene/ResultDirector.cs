using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResultDirector : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;
    public static Ending ending;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showResultMsg() {
        List<string> endMsg = new List<string>();
        endMsg.Add($"{ending.name}Ç…àÁÇ¡ÇΩÅI");
        endMsg.AddRange(ending.description.ToList<string>());
        dialogManager.showDialog(endMsg.ToArray());
    }
}
