using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TranslateItem : MonoBehaviour
{
    [Header("Выбор Языка")]
    public string Language;
    public TextMeshProUGUI Text;
    
    [Header("Перевод")]
    public string TextRussian;
    public string TextEnglish;
    public string TextTurkish;
 
    private void FixedUpdate ()
    {
        Language = PlayerPrefs.GetString("Lang");

        if(Language == "" || Language == "Russia")
        {
           Text.text = TextRussian;
        }
        
        if (Language == "English")
        {
           Text.text = TextEnglish;
        }
        
        if (Language == "Turkish")
        {
           Text.text = TextTurkish;
        }
    }
}