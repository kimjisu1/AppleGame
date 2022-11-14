﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Linq;

public class Slot : MonoBehaviour, IDropHandler
{
	public int slotId;
    public int itemId;
	private Inventory inven;

	void Start()
	{
		inven = GameObject.Find("Inventory").GetComponent<Inventory>();
	}

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItemData = eventData.pointerDrag.GetComponent<ItemData>(); //드롭된 아이템
        if (droppedItemData == null || droppedItemData.itemState != ItemData.eItemState.move)
        {
            return;
        }
        Debug.Log("droppedItemData.slotId : " + droppedItemData.slotId);
        Debug.Log("================");
        Debug.Log("itemId : " + itemId);
        Debug.Log("droppedItemData.invenItem.itemId: " + droppedItemData.invenItem.itemId);
        Slot oriSlot = inven.slotList[droppedItemData.slotId];
        if (itemId == -1) //물체가 빈 슬롯위라면
        //if (inven.invenItemList[slotId].itemId == -1) //물체가 빈 슬롯위라면
        {
            //빈슬롯에는 옮기지 않아보자.
            //inven.invenItemList[droppedItemData.slotId] = new InvenItem(); //원래위치에 빈아이템넣고
            //inven.invenItemList[slotId] = droppedItemData.invenItem; //이동위치에 넣는다.

            //itemId = droppedItemData.invenItem.itemId;
            //inven.slotList[droppedItemData.slotId].GetComponent<Slot>().itemId = inven.invenItemList[droppedItemData.slotId].itemId;

            //droppedItemData.slotId = slotId;



            //빈슬롯에는 옮기지 않아보자.
            //inven.invenItemList[droppedItemData.slotId] = new InvenItem(); //원래위치에 빈아이템넣고
            //inven.invenItemList[slotId] = droppedItemData.invenItem; //이동위치에 넣는다.

            //inven.slotList[droppedItemData.slotId].GetComponent<Slot>().itemId = inven.invenItemList[droppedItemData.slotId].itemId;
            //Debug.Log("inven.invenItemList[droppedItemData.slotId].itemId: " + inven.invenItemList[droppedItemData.slotId].itemId);

            oriSlot.itemId = -1;
            droppedItemData.slotId = slotId;
        }
        //     else if (droppedItemData.slotId != slotId) //물체가 다른물체위라면
        //     {
        //         Transform curItem = this.transform.GetChild(0); //슬롯의 자식오브젝트
        //         ItemData curItemData = curItem.GetComponent<ItemData>(); //자식오브젝트의 아이템데이터
        //         curItemData.slotId = droppedItemData.slotId; //스왑 : 자식오브젝트의 슬롯아이디를 드롭아이템데이터 슬롯아이디로 -> 반대도 있어야함

        //         Transform droppedSlotTr = inven.slotList[droppedItemData.slotId].transform;
        //         curItem.transform.SetParent(droppedSlotTr);
        //curItem.transform.position = droppedSlotTr.position;

        //         droppedSlotTr.GetComponent<Slot>().itemId = inven.invenItemList[droppedItemData.slotId].itemId;
        //         itemId = droppedItemData.invenItem.itemId;
        //         droppedItemData.slotId = slotId;

        //droppedItemData.transform.SetParent(this.transform);
        //droppedItemData.transform.position = this.transform.position;

        //inven.invenItemList[droppedItemData.slotId] = curItemData.invenItem;
        //inven.invenItemList[slotId] = droppedItemData.invenItem;

        //     }
        else if(itemId != droppedItemData.invenItem.itemId) //물체가 다른물체위라면
        {
            ItemData curItemData = transform.GetComponentInChildren<ItemData>(); //자식오브젝트의 아이템데이터
            //int curItemId = curItemData.invenItem.itemId;
            //int curSlotId = curItemData.slotId;

            int tempId =  oriSlot.itemId;
            oriSlot.itemId = itemId;
            itemId = tempId;

            curItemData.slotId = oriSlot.slotId;
            droppedItemData.slotId = slotId;

            



            //curItemData.slotId = droppedItemData.slotId; //스왑 : 자식오브젝트의 슬롯아이디를 드롭아이템데이터 슬롯아이디로 -> 반대도 있어야함

            //Transform droppedSlotTr = inven.slotList[droppedItemData.slotId].transform;
            //curItem.transform.SetParent(droppedSlotTr);
            //curItem.transform.position = droppedSlotTr.position;

            //droppedSlotTr.GetComponent<Slot>().itemId = inven.invenItemList[droppedItemData.slotId].itemId;
            //itemId = droppedItemData.invenItem.itemId;
            //droppedItemData.slotId = slotId;

            //droppedItemData.transform.SetParent(this.transform);
            //droppedItemData.transform.position = this.transform.position;

            //inven.invenItemList[droppedItemData.slotId] = curItemData.invenItem;
            //inven.invenItemList[slotId] = droppedItemData.invenItem;

        }
    }

}
















//using UnityEngine;
//using System.Collections;
//using UnityEngine.EventSystems;
//using System;

//public class Slot : MonoBehaviour, IDropHandler
//{
//    public int slotId;
//    public InvenItem invenItem;
//    //public int curItemId;
//    //private Inventory inven;

//    void Start()
//    {
//        //inven = GameObject.Find("Inventory").GetComponent<Inventory>();
//    }

//    void Swap<T>(ref T t1, ref T t2)
//    {
//        T swapT = t1;
//        t1 = t2;
//        t2 = swapT;
//    }

//    public void OnDrop(PointerEventData eventData)
//    {
//        ItemData droppedItemData = eventData.pointerDrag.GetComponent<ItemData>();
//        if (droppedItemData == null || droppedItemData.itemState != ItemData.eItemState.move)
//        {
//            return;
//        }
//        if (invenItem.itemId == -1) //물체가 빈 슬롯위라면
//        {
//            //빈슬롯에는 옮기지 않아보자.
//            //inven.invenItemList[droppedItemData.slotId] = new InvenItem(); //원래위치에 빈아이템넣고
//            //inven.invenItemList[slotId] = droppedItemData.invenItem; //이동위치에 넣는다.

//            //Slot droppedSlotData = droppedItemData.GetComponentInParent<Slot>();

//            Swap(ref droppedItemData.slotId, ref slotId);

//            //curItemId = droppedItemData.invenItem.itemId;
//            //inven.slotList[droppedItemData.slotId].GetComponent<Slot>().curItemId = inven.invenItemList[droppedItemData.slotId].itemId;

//            //invenItem = droppedItemData.invenItem;

//            //droppedItemData.slotId = slotId;
//        }
//        else if (droppedItemData.slotId != slotId) //물체가 다른물체 위라면
//        {
//            Slot curSlot = this;
//            Slot droppedSlot = inven.slotList[droppedItemData.slotId];

//            Transform curItem = this.transform.GetChild(0); //현재 아이템
//            curItem.SetParent(droppedSlot.transform, false);
//            //curItem.transform.position = droppedSlot.transform.position;

//            ItemData curItemData = curItem.GetComponent<ItemData>();

//            int swapSlotId = droppedItemData.slotId;
//            droppedItemData.slotId = curItemData.slotId;
//            curItemData.slotId = swapSlotId;

//            InvenItem droppedInvenItem = inven.invenItemList[droppedItemData.slotId]; //드랍되기전 아이템
//            InvenItem curInvenItem = inven.invenItemList[slotId]; //현재 인벤아이템

//            droppedSlot.curItemId = droppedInvenItem.itemId;
//            curSlot.curItemId = droppedItemData.invenItem.itemId;

//            droppedItemData.slotId = slotId;

//            droppedItemData.transform.SetParent(transform, false);
//            //droppedItemData.transform.position = this.transform.position;

//            inven.invenItemList[droppedItemData.slotId] = curItemData.invenItem;
//            inven.invenItemList[slotId] = droppedItemData.invenItem;

//        }
//    }
//}