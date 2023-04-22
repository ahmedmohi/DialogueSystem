using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBubbleWriter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMain;

    public void WriteNewText(DialogueSpeechData speechData)
    {
        textMain.text = speechData.text;
    }
}
