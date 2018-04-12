﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerDialogue : MonoBehaviour
{
    [Header("Customer Food Value")]
    //public int customerFoodValue = 0; IGNORE

    public bool textDisplayed;

    [Header("Text Box UI")]
    public Text responseText;
    public Image speechBubble;

    [Header("Customer Name - If Applicable")]
    public string customerName;

    void Start()
    {
        responseText.text = "";
        speechBubble.gameObject.SetActive(false);
    }

    public void UpdateText()
    {
        textDisplayed = true;


        //float foodPercentage = GameManager.instance.foodPercentage;

        StartCoroutine(DialogueDelay());

        //string responseToDisplay = gameObject.GetComponent<Health.HealthResponses>().GetHealthResponse(customerFoodValue);

        //string responseToDisplay = gameObject.GetComponent<Health.HealthyResponses>().GetHealthResponse(foodPercentage);
        //responseText.text = responseToDisplay;


        //responseText.text = (customerName + " : " + responseToDisplay);
        //Used if we want customers to have a name and have it show up when the text appears
    }

    public IEnumerator DialogueDelay()
    {
        yield return new WaitForSeconds(1.5f);
        float foodPercentage = GameManager.instance.foodPercentage;

        string responseToDisplay = gameObject.GetComponent<Health.HealthyResponses>().GetHealthResponse(foodPercentage);
        speechBubble.gameObject.SetActive(true);
        responseText.text = responseToDisplay;

        StopCoroutine(DialogueDelay());
    }
}
