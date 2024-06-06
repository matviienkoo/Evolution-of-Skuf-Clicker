using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class LargeNumberClickableObject : MonoBehaviour
{
    private float timer = 1;

    [Header("Система обработки денег")]
    public LargeNumber largeNumber;

    [Header("Добавить или Вычесть деньги")]
    public bool add;
    public LargeNumber clickAmount;

    [Header("Количество денег в секунду")]
    public bool autoClick;
    public float autoClickRate = .5f;
    public LargeNumber autoClickAmount;

    [Space(10)] [Header("Text Display")]
    public bool displayFullText;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI MoneySecText;

    public double MoneyAdd;
    public string string_MoneyAdd;

    public double MoneySecAdd;
    public string string_MoneySecAdd;

    private void Start()
    {
        UpdateText();
    }
    private void OnValidate()
    {
        largeNumber.ClampList();
        clickAmount.ClampList();
        autoClickAmount.ClampList();
        UpdateText();
    }

    public void UpdateMoneyToAdd()
    {
        add = true;
        string_MoneyAdd = MoneyAdd.ToString();
        char[] numbers = string_MoneyAdd.ToCharArray();
        clickAmount.Assign(clickAmount.StringToLargeNumber(string_MoneyAdd));
    }
    public void UpdateSecMoneyToAdd()
    {
        string_MoneySecAdd = MoneySecAdd.ToString();
        char[] numbers = string_MoneySecAdd.ToCharArray();
        autoClickAmount.Assign(autoClickAmount.StringToLargeNumber(string_MoneySecAdd));
    }
    public void UpdateMoneyToSub()
    {
        add = false;
        string_MoneyAdd = MoneyAdd.ToString();
        char[] numbers = string_MoneyAdd.ToCharArray();
        clickAmount.Assign(clickAmount.StringToLargeNumber(string_MoneyAdd));
    }

    public void OnPointerClick()
    {
        if (largeNumber == null)
            largeNumber = new LargeNumber();
        if (clickAmount == null)
            clickAmount = new LargeNumber();

        if (add)
        {
            largeNumber.AddLargeNumber(clickAmount);
            UpdateText();
        }
        else
        {
            largeNumber.SubLargeNumber(clickAmount);
            UpdateText();
        }
    }


    public void UpdateText()
    {
        if (largeNumber == null)
            largeNumber = new LargeNumber();
        if (clickAmount == null)
            clickAmount = new LargeNumber();

        if (displayFullText)
        {
            MoneyText.text = largeNumber.LargeNumberToString();
            MoneySecText.text = autoClickAmount.LargeNumberToString();
        }
        else
        {
            MoneyText.text = largeNumber.LargeNumberToShortString();
            MoneySecText.text = autoClickAmount.LargeNumberToShortString();
        }
    }
    private void Update()
    {
        if (autoClickAmount == null)
        {
            autoClickAmount = new LargeNumber();
        }
        
        if (autoClick){
        timer -= Time.deltaTime;
        if (timer < autoClickRate)
            timer = 1;
        else
            return;

        if (add)
        {
            largeNumber.AddLargeNumber(autoClickAmount);
            UpdateText();
        }
        else
        {
            largeNumber.SubLargeNumber(autoClickAmount);
            UpdateText();
        }
        }
    }
}
