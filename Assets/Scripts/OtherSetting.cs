﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using YG;

namespace YG.Example{
public class OtherSetting : MonoBehaviour 
{
    public YandexGame sdk;
    [Header("Язык игры")]
    public string Language = "Russia";
    private int Language_Int;

    [Space(10)]
    public Image Img_Language;
    public Sprite Sprite_Russia;
    public Sprite Sprite_English;
    public Sprite Sprite_Turkish;

    [Header("Музыка")]
    public bool Music_On = true;
    public bool Music_Off = false;
    private int Music_Int;
    [Space(10)]
    public Image Img_Sound;
    public Sprite Sprite_Spound_On;
    public Sprite Sprite_Spound_Off;

    private void Start ()
    {
        // Поставить нужный язык
        Language_Int = PlayerPrefs.GetInt("Language_Int");
        Language = PlayerPrefs.GetString("Lang");

        if (Language_Int == 1)
        Img_Language.sprite = Sprite_English;
        if (Language_Int == 2)
        Img_Language.sprite = Sprite_Turkish;
        if (Language_Int == 3)
        Img_Language.sprite = Sprite_Russia;

        // Обновить язык в яндексе
        SwitchLanguage(YandexGame.savesData.language);

        // Выключить музыку
        Music_Int = PlayerPrefs.GetInt("Music_Int");
        if (Music_Int == 1){
        Music_On = false;
        Music_Off = true;
        Img_Sound.sprite = Sprite_Spound_Off;
        }
        // Включить музыку
        if (Music_Int == 2){
        Music_Off = false;
        Music_On = true;
        Img_Sound.sprite = Sprite_Spound_On;
        Music_Int = 0;
        }
    }

    public void Music_Update ()
    {
        Music_Int ++;
        PlayerPrefs.SetInt("Music_Int",Music_Int);

        // Выключить музыку
        if (Music_On == true && Music_Int == 1)
        {
            Music_On = false;
            Music_Off = true;
            Img_Sound.sprite = Sprite_Spound_Off;
        }
        // Включить музыку
        if (Music_Off == true && Music_Int == 2)
        {
            Music_Off = false;
            Music_On = true;
            Img_Sound.sprite = Sprite_Spound_On;
            Music_Int = 0;
        }
    }

    private void Awake(){
    SwitchLanguage(YandexGame.savesData.language);
    }
    private void OnEnable() => YandexGame.SwitchLangEvent += SwitchLanguage;
    private void OnDisable() => YandexGame.SwitchLangEvent -= SwitchLanguage;
    public void SwitchLanguage(string lang)
    {
        switch (lang)
        {
            case "ru":
                Language = "Russia"; 
                Img_Language.sprite = Sprite_Russia;
                Language_Int = 0;
                break;
            case "tr":
                Language = "Turkish";
                Img_Language.sprite = Sprite_Turkish;
                Language_Int = 2;
                break;
            case "en":
                Language = "English";
                Img_Language.sprite = Sprite_English;
                Language_Int = 1;
                break;
            default:
                Language = "Russia"; 
                Img_Language.sprite = Sprite_Russia;
                Language_Int = 0;
                break;
        }
        PlayerPrefs.SetString("Lang", Language);
        PlayerPrefs.SetInt("Language_Int",Language_Int);
    }

    public void Language_Update ()
    {
        Language_Int ++;

        // Поставить английский язык
        if (Language_Int == 1)
        {
            Language = "English";
            Img_Language.sprite = Sprite_English;
        }
        // Поставить турецкий язык
        if (Language_Int == 2)
        {
            Language = "Turkish";
            Img_Language.sprite = Sprite_Turkish;
        }
        // Поставить русский язык
        if (Language_Int >= 3)
        {
            Language = "Russia"; 
            Img_Language.sprite = Sprite_Russia;
            Language_Int = 0;
        }
        PlayerPrefs.SetString("Lang", Language);
        PlayerPrefs.SetInt("Language_Int",Language_Int);
    }
}
}