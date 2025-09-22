using TMPro;
using UnityEngine;

public class DialougeLines : MonoBehaviour
{
    [SerializeField] string[] voicelines;
    [SerializeField] TMP_Text subtitleUI;

    int CurrentLineIndex = 0;

    public void PlayNextLine()
    {
        CurrentLineIndex++;
        subtitleUI.text = voicelines[CurrentLineIndex];
       
    }
}
