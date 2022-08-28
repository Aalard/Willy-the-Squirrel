using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMessage : MonoBehaviour
{
    public Text LevelUpText;
    public Score score;
    public string message = "error";
    public GameObject textParent;
    public TimeDeltaTime GMScript;
    // Start is called before the first frame update
    public void DisplayRightMessage()
    {
        if (GMScript.stop == false) {
            if (GMScript.level==1)
            {
                message = "FASTER!!!";
                StartCoroutine(DisplayMessage());
            }
            else if (GMScript.level == 2)
            {
                message = "NICE!!!";
                StartCoroutine(DisplayMessage());
            }
            else if (GMScript.level == 3)
            {
                message = "KEEP GOING!!!";
                StartCoroutine(DisplayMessage());
            }
            else if (GMScript.level == 4)
            {
                message = "SOMETHING BIG IS COMING!!!";
                StartCoroutine(DisplayMessage());
            }
            else if (GMScript.level == 5)
            {
                message = "ACRONGEDDON!!!";
                StartCoroutine(DisplayMessage());
            }
        } else {
            textParent.SetActive(false); }
    }
    
    public IEnumerator DisplayMessage()
    {
        textParent.SetActive(true);
        if (score.score>=0)
        LevelUpText.text = message;
        yield return new WaitForSeconds(1);
        textParent.SetActive(false);
    }
}
