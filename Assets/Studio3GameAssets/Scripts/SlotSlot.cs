﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotSlot : MonoBehaviour, IDropHandler {


    public GameObject itembeingdruggedslot;
    private IEnumerator coroutine;


    public GameObject item
    {

        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }


    }





    #region IDropHandler implementation
    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            DragHandeler.itemBeingDragged.transform.SetParent(transform);
            ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
            itembeingdruggedslot = item;
        }
        if (itembeingdruggedslot.tag.Contains("Apple")&& this.gameObject.tag == "ChoppingBoard")
        {

            
            //itembeingdruggedslot.GetComponentInChildren<GameObject>().SetActive(false);
            itembeingdruggedslot.transform.GetChild(1).gameObject.SetActive(true);
            itembeingdruggedslot.transform.GetChild(0).gameObject.SetActive(false);
        }

    }
    #endregion





    void Update()
    {
  

    }


}



