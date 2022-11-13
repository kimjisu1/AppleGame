//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;

//public class Inventory : MonoBehaviour
//{
//    private ItemDatabase database;
//    public int slotAmount = 16;


//    public GameObject inventorySlot;
//    public GameObject inventoryItem;

//    [HideInInspector] public List<GameObject> slotList = new List<GameObject>(); //슬롯리스트 - 
//    [HideInInspector] public List<InvenItem> invenItemList = new List<InvenItem>(); //인벤아이템 - 

//    void Start()
//    {
//        database = GetComponent<ItemDatabase>();

//        GameObject slotPanel = GameObject.Find("SlotPanel");
//        for (int i = 0; i < slotAmount; i++)
//        {
//            //해당슬롯 빈 오브젝트정보 셋팅
//            invenItemList.Add(new InvenItem()); 

//            //슬롯오브젝트 추가
//            slotList.Add(Instantiate(inventorySlot));
//            slotList[i].GetComponent<Slot>().slotId = i;
//            slotList[i].transform.SetParent(slotPanel.transform);
//        }
//        AddItem();
//    }

//    public void SortItem()
//    {
//        for (int i = 0; i < invenItemList.Count; i++)
//        {
//            if(invenItemList[i].itemId == -1) //비어있다면...
//            {
//                invenItemList.RemoveAt(i);
//            }
//        }
//    }

//    public void AddItem(int slotId)
//    {

//    }
//   public void RemoveItem(int slotId)
//    {
//        //invenItemList.Remove(invenItem);
//        invenItemList[slotId] = new InvenItem();
//    }

//    public void AddItem()
//    {
//        for (int i = 0; i < database.db_InvenItem.Count; i++)
//        {
//            GameObject itemObj = Instantiate(inventoryItem);
//            itemObj.transform.SetParent(slotList[i].transform);
//            itemObj.transform.position = Vector2.zero;

//            int itemId = database.db_InvenItem[i].itemId;

//            InvenItem invenItemAdd = database.GetInvenItem(itemId);
//            invenItemAdd.itemId = itemId;
//            invenItemList[i] = invenItemAdd;

//            ItemData itemData = slotList[i].GetComponentInChildren<ItemData>();
//            itemData.invenItem = invenItemAdd;
//            itemData.database = database;
//            itemData.slotId = i;
//            itemData.leftStack = invenItemAdd.stack;

//            ItemType itemTypeAdd = database.GetItemType(itemId);
//            itemObj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Items/" + itemTypeAdd.slug);

//            slotList[i].GetComponent<Slot>().itemId = itemId;

//            itemObj.name = "Item: " + itemTypeAdd.title;
//            //slotList[i].name = "Slot: " + itemTypeAdd.title;

//        }


//    }

//}























using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour
{
    private ItemDatabase database;
    public int slotAmount = 16;


    public GameObject inventorySlot;
    public GameObject inventoryItem;

    [HideInInspector] public List<Slot> slotList = new List<Slot>(); //슬롯리스트 - 
    [HideInInspector] public List<InvenItem> invenItemList = new List<InvenItem>(); //인벤아이템 - 

    void Start()
    {
        //database = GetComponent<ItemDatabase>();
        database = ItemDatabase.instance;

        InitItem();
        AddItem();
    }

    /// <summary>
    /// 초기셋팅 - 슬롯셋팅, 빈인벤아이템셋팅
    /// </summary>
    private void InitItem()
    {
        GameObject slotPanel = GameObject.Find("SlotPanel");
        for (int i = 0; i < slotAmount; i++)
        {
            //슬롯오브젝트 추가
            Slot slot = Instantiate(inventorySlot, slotPanel.transform).GetComponent<Slot>();
            slot.slotId = i;
            slot.itemId = -1;
            slotList.Add(slot);

            //해당슬롯 빈 오브젝트정보 셋팅
            invenItemList.Add(new InvenItem());
        }
    }

    /// <summary>
    /// 아이템추가 - 인벤에 있는 아이템들 셋팅
    /// </summary>
    private void AddItem()
    {
        for (int i = 0; i < database.db_InvenItem.Count; i++)
        {
            Slot slot = slotList[i];
            ItemData itemData = Instantiate(inventoryItem, slot.transform).GetComponent<ItemData>();

            int itemId = database.db_InvenItem[i].itemId;

            ItemType itemType = database.GetItemType(itemId);
            itemData.name = "Item: " + itemType.title;

            InvenItem invenItem = database.GetInvenItem(itemId);
            invenItem.itemId = itemId;
            invenItemList[i] = invenItem;

            itemData.SetItemData(i, invenItem);

            slot.itemId = itemId;


        }
    }

    public void SortItem()
    {
        for (int i = 0; i < invenItemList.Count; i++)
        {
            if (invenItemList[i].itemId == -1) //비어있다면...
            {
                invenItemList.RemoveAt(i);
            }
        }
    }

    public void AddItem(int slotId)
    {

    }
    public void RemoveItem(int slotId)
    {
        //invenItemList.Remove(invenItem);
        invenItemList[slotId] = new InvenItem();
    }
}





//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;

//public class Inventory : MonoBehaviour
//{
//    private ItemDatabase database;
//    public int slotAmount = 16;


//    public GameObject inventorySlot;
//    public GameObject inventoryItem;

//    [HideInInspector] public List<Slot> slotList = new List<Slot>(); //슬롯리스트 - 
//    //[HideInInspector] public List<InvenItem> invenItemList = new List<InvenItem>(); //인벤아이템 - 저장용

//    void Start()
//    {
//        //database = GetComponent<ItemDatabase>();
//        database = ItemDatabase.instance;

//        InitItem();
//        AddItem();
//    }

//    /// <summary>
//    /// 초기셋팅 - 슬롯셋팅, 빈인벤아이템셋팅
//    /// </summary>
//    private void InitItem()
//    {
//        GameObject slotPanel = GameObject.Find("SlotPanel");
//        for (int i = 0; i < slotAmount; i++)
//        {
//            //슬롯오브젝트 추가
//            Slot slot = Instantiate(inventorySlot, slotPanel.transform).GetComponent<Slot>();
//            slot.slotId = i;
//            slot.invenItem = new InvenItem();
//            slotList.Add(slot);

//            //해당슬롯 빈 오브젝트정보 셋팅
//            //invenItemList.Add(new InvenItem());
//        }
//    }

//    /// <summary>
//    /// 아이템추가 - 인벤에 있는 아이템들 셋팅
//    /// </summary>
//    private void AddItem()
//    {
//        for (int i = 0; i < database.db_InvenItem.Count; i++)
//        {
//            Slot slot = slotList[i];

//            ItemData itemData = Instantiate(inventoryItem, slot.transform).GetComponent<ItemData>();

//            int itemId = database.db_InvenItem[i].itemId;

//            ItemType itemType = database.GetItemType(itemId);
//            itemData.name = "Item: " + itemType.title;

//            InvenItem invenItem = database.GetInvenItem(itemId);
//            invenItem.itemId = itemId;
//            //invenItemList[i] = invenItem;

//            itemData.SetItemData(i, invenItem);

//            slot.invenItem = invenItem;
//        }
//    }

//    public void SortItem()
//    {
//        for (int i = 0; i < invenItemList.Count; i++)
//        {
//            if (invenItemList[i].itemId == -1) //비어있다면...
//            {
//                invenItemList.RemoveAt(i);
//            }
//        }
//    }

//    public void AddItem(int slotId)
//    {

//    }
//    public void RemoveItem(int slotId)
//    {
//        //invenItemList.Remove(invenItem);
//        invenItemList[slotId] = new InvenItem();
//    }



//}