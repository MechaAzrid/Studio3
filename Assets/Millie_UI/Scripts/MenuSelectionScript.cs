﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelectionScript : MonoBehaviour {


    //public GameObject correspondingIngredients;
    public Button menuItems;
    public Color selectedItem;
    public Color unselectedItem;
    public Image colour;

    [Header("Cards")]
    public GameObject Ingredients;

    public MenuCounterInventory MC;

    public bool clicked = false;

    public float cost;
   // public bool buttonsDisabled = false;


    
    // Use this for initialization
	void Start ()
    {
        Ingredients.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (MC.counter >= 2)
        {

            
            menuItems.GetComponent<Button>().interactable = false;
            Debug.Log("Button Deactivated");
            
        }

       
        //If the 
        else if (MC.counter == 0)
        {
            clicked = false;
            colour.GetComponent<Image>().color = unselectedItem;
            //correspondingIngredients.SetActive(false);
            menuItems.GetComponent<Button>().interactable = true;

            Ingredients.SetActive(false);
        }

        

    }

    //void "MenuItems" Buttons here - make corresponding ingredients visible - save quantity

    public void MenuItemButton()
    {

        if (clicked == false)
        {

            //show ingredients panel
            //correspondingIngredients.SetActive(true);


            colour.GetComponent<Image>().color = selectedItem;
            clicked = true;
            MC.tempMoney -= cost;
            print(cost);

            // ingredients appear on click
            Ingredients.SetActive(true);



            //if ingredients have been chosen then add counter
            MC.counter = MC.counter + 1;

            
        }

        
      

        else
        {
            clicked = false;
            //correspondingIngredients.SetActive(false);
            colour.GetComponent<Image>().color = unselectedItem;


            //if ingredients were chosen then subtract counter
            MC.counter = MC.counter - 1;
            MC.tempMoney += cost;

            // ingredients disappear on click 
            Ingredients.SetActive(false);

        }

       


    }

    
}


   






