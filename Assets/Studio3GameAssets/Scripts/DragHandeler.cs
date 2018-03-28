﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {


    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;

    //To trick the dragging problem. This instead of clicking double, it covers the button and puts a clone on top.
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
   




    #region IBeginDragHandler implementation


    public void OnBeginDrag(PointerEventData eventData)
    {
        
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;



        //Condition for make something happen
        if (itemBeingDragged.tag.Contains("Mango"))
        {
            Debug.Log("Mango being Drugged");
            if (GameObject.Find("Ingredient_Mango(Clone)") == null)
            {
            Instantiate(itemBeingDragged, startPosition, startParent.transform.rotation, MangoInstantiationPosition.transform.parent);
            }
        }

        if (itemBeingDragged.tag.Contains("Lettuce"))
        {
            Debug.Log("Lettuce being Drugged");
        }
        if (itemBeingDragged.tag.Contains("Onion"))
        {
            Debug.Log("Onion being Drugged");
        }
        if (itemBeingDragged.tag.Contains("Carrot"))
        {
            Debug.Log("Carrot being Drugged");
        }

        if (itemBeingDragged.tag.Contains("Potato"))
        {
            Debug.Log("Potato being Drugged");
        }

        if (itemBeingDragged.tag.Contains("Apple"))
        {
            Debug.Log("Apple being Drugged");

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
        if(transform.parent == startParent)
        {
        
            transform.position = startPosition;
        }






    }
    #endregion

}
