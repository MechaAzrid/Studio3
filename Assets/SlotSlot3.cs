﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotSlot3 : MonoBehaviour, IDropHandler
{


    //public string itemString
    //{

    //    get
    //    {
    //        if (transform.childCount > 0)
    //        {
    //            return transform.GetChild(0).gameObject.tag;
    //        }
    //        return null;
    //    }




    //}


  

    public GameObject item3
    {

        get
        {
            if (transform.childCount > 0 )
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }


    }
    #region IDropHandler implementation
    public void OnDrop(PointerEventData eventData)
    {
        if (!item3)
        {
            DragHandeler.itemBeingDragged.transform.SetParent(transform);
            ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
        }
    }
    #endregion
}