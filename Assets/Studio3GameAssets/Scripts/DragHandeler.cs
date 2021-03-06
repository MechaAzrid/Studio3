﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {


    public static GameObject itemBeingDragged;

    public CustomerManager CM;

    public GameObject itemBeingDraggedNotStatic;

    Vector3 startPosition;
    Transform startParent;



    //To trick the dragging problem. This instead of clicking double, it covers the button and puts a clone on top.
    [Header("To trick the dragging problem. This instead of clicking double, it covers the button and puts a clone on top.")]
    public GameObject MangoInstantiationPosition;
    public GameObject LettuceInstantiationPosition;
    public GameObject OnionInstantiationPosition;
    public GameObject CarrotInstantiationPosition;
    public GameObject PotatoInstantiationPosition;
    public GameObject PattyInstantiationPosition;
    public GameObject AppleInstantiationPosition;
    public GameObject ShallotInstantiationPosition;
    public GameObject CheeseInstantiationPosition;
    public GameObject SausageInstantiationPosition;

    [Header("Food")]
    public Ingredient ingredient;
    public Meal meal;


    [Header ("Sound")]
    public GameObject objectForSoundBeingDragged;
    public AudioSource audioBeingDrugged;
    public AudioClip draggedFood;

    [Header("Mixer,ChoppingBoard, Fryer Gameobjects")]
    public GameObject Fryer;
    public GameObject ChoppingBoard;
    public GameObject Box;



    [Header("Canvas")]
    public Canvas canvas;
    public GameObject canvasGameobject;

    //OnClickMaketheImageAppear
    public static RectTransform imageGameObjectBeingDrugged;


    void Start()
    {

        canvasGameobject = GameObject.Find("Canvas");
        Fryer = GameObject.Find ("UI_Fryer");

        CM = GameObject.Find("_CustomerManager").GetComponent<CustomerManager>();

        foreach(Ingredient ing in CM.ingredientList)
        {
            if (this.gameObject.tag.Contains(ing.ingredientName))
            {
                ingredient = ing;
            }
        }

    }
   

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;

        //To help reference from the other script slot slot
        itemBeingDraggedNotStatic = itemBeingDragged;


        //Condition for make something happen
        if (itemBeingDragged.tag.Contains("Mango"))
        {


            Debug.Log("Mango being Drugged");


            itemBeingDragged = objectForSoundBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

            // Search for mango clone and if it doesnt exist make a copy on top of the Mango button
            //if (GameObject.Find("Ingredient_Mango(Clone)") == null)
            //{
            //Instantiate(itemBeingDragged, startPosition, startParent.transform.rotation, MangoInstantiationPosition.transform.parent);



         //  itemBeingDragged.transform.parent = canvas.transform;
            itemBeingDragged.transform.localScale = new Vector3(2f, 2f, 2f);

            //itemBeingDragged.transform.parent = canvasGameobject.transform;
            //}
        }




        if (itemBeingDragged.tag.Contains("Lettuce"))
        {
            Debug.Log("Lettuce being Drugged");

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

          //  itemBeingDragged.transform.parent = canvas.transform;
            itemBeingDragged.transform.localScale = new Vector3(2f, 2f, 0);

        }
        if (itemBeingDragged.tag.Contains("Onion"))
        {
            Debug.Log("Onion being Drugged");

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

          //  itemBeingDragged.transform.parent = canvas.transform;
            itemBeingDragged.transform.localScale = new Vector3(2f, 2f, 0);
        }
        if (itemBeingDragged.tag.Contains("Carrot"))
        {
            Debug.Log("Carrot being Drugged");

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

           // itemBeingDragged.transform.parent = canvas.transform;
            itemBeingDragged.transform.localScale = new Vector3(2f, 2f, 0);
        }

        if (itemBeingDragged.tag.Contains("Potato"))
        {
            Debug.Log("Potato being Drugged");

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
             audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

           // itemBeingDragged.transform.parent = canvas.transform;
            itemBeingDragged.transform.localScale = new Vector3(2f, 2f, 0);
        }

        if (itemBeingDragged.tag.Contains("Apple"))
        {
            Debug.Log("Apple being Drugged");

<<<<<<< HEAD
=======






>>>>>>> Millie
            //imageGameObjectBeingDrugged = itemBeingDragged;
            itemBeingDragged.GetComponent<Image>();
   

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

            itemBeingDragged.transform.localScale = new Vector3(2f, 2f, 0);
        }

        if (itemBeingDragged.tag.Contains("Sausage"))
        {
            Debug.Log("Sausage being Drugged");

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

            itemBeingDragged.transform.localScale = new Vector3(2f, 2f, 0);
        }
        if (itemBeingDragged.tag.Contains("Patty"))
        {
            Debug.Log("Patty being Drugged");

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

            itemBeingDragged.transform.localScale = new Vector3(2f, 2f, 0);
        }

        if (itemBeingDragged.tag.Contains("Leek"))
        {
            Debug.Log("Leek being Drugged");

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

            itemBeingDragged.transform.localScale = new Vector3(2f, 2f, 0);
        }

        if (itemBeingDragged.tag.Contains("Cheese"))
        {
            Debug.Log("Cheese being Drugged");

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

            itemBeingDragged.transform.localScale = new Vector3(2f, 2f, 0);

        }


        //FruitSalad code
        if (itemBeingDragged.tag.Contains("FruitSalad"))
        {
            Debug.Log("FruitSalad being Drugged");

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

            itemBeingDragged.transform.parent = canvasGameobject.transform;

            foreach (Meal ml in CM.mealList)
            {
                if (this.gameObject.tag.Contains(ml.mealName))
                {
                    meal = ml;
                }
            }

        }

        //Burger code
        if (itemBeingDragged.tag.Contains("Burger"))
        {
            Debug.Log("Burger being Drugged");

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

            itemBeingDragged.transform.parent = canvasGameobject.transform;

            foreach (Meal ml in CM.mealList)
            {
                if (this.gameObject.tag.Contains(ml.mealName))
                {
                    meal = ml;
                }
            }

        }

        //CheesyChips code
        if (itemBeingDragged.tag.Contains("CheeseChips"))
        {
            Debug.Log("CheeseChips being Drugged");

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

            itemBeingDragged.transform.parent = canvasGameobject.transform;

            foreach (Meal ml in CM.mealList)
            {
                if (this.gameObject.tag.Contains(ml.mealName))
                {
                    meal = ml;
                }
            }

        }

        //HotDog code
        if (itemBeingDragged.tag.Contains("HotDog"))
        {
            Debug.Log("Hotdog being Drugged");

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

            itemBeingDragged.transform.parent = canvasGameobject.transform;

            foreach (Meal ml in CM.mealList)
            {
                if (this.gameObject.tag.Contains(ml.mealName))
                {
                    meal = ml;
                }
            }

        }

        //PotatoSoup code
        if (itemBeingDragged.tag.Contains("PotatoSoup"))
        {
            Debug.Log("PotatoSoup being Drugged");

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

            itemBeingDragged.transform.parent = canvasGameobject.transform;

            foreach (Meal ml in CM.mealList)
            {
                if (this.gameObject.tag.Contains(ml.mealName))
                {
                    meal = ml;
                }
            }

        }

        //Sandwich code
        if (itemBeingDragged.tag.Contains("Sandwich"))
        {
            Debug.Log("Sandwich being Drugged");

            objectForSoundBeingDragged = itemBeingDragged;
            objectForSoundBeingDragged.GetComponent<AudioSource>();
            audioBeingDrugged.PlayOneShot(draggedFood, 0.2f);

            itemBeingDragged.transform.parent = canvasGameobject.transform;

            foreach (Meal ml in CM.mealList)
            {
                if (this.gameObject.tag.Contains(ml.mealName))
                {
                    meal = ml;
                }
            }

        }
        //Instantiate();
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        

     





    }
    #endregion





    #region IDragHandler implementation


    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition;



    }
    #endregion





    #region IDragHandler implementation


    public void OnEndDrag(PointerEventData eventData)
    {
   

        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {

            transform.position = startPosition;

            transform.localScale = new Vector3(1f, 1f, 1f);



        }
     //   else 


            //transform.localScale = new Vector3(1f, 1f, 1f);


       

    







    }
    #endregion

}
