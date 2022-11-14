using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryItem;
    public GameObject inventorySlot;
    [HideInInspector] public List<Slot> slotList = new List<Slot>(); //슬롯리스트 - 
    [HideInInspector] public List<ItemData> itemDataList = new List<ItemData>(); //인벤아이템리스트 - 
    public int slotAmount = 16;

    private ItemDatabase database;


    #region 유니티 함수
    /// <summary>
    /// 스타트
    /// </summary>
    private void Start()
    {
        database = ItemDatabase.instance;

        InitSlot(); //슬롯초기화
        InitItem(); //아이템초기화
    }

    /// <summary>
    /// 업데이트
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SortItem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CreateOrAddItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CreateOrAddItem(101);
        }
        //if (Input.GetKeyDown(KeyCode.Alpha2)) //증가
        //{
        //    slotList[itemDataList[4].slotId].itemId = -1;
        //    itemDataList[4].slotId++;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3)) //감소
        //{
        //    slotList[itemDataList[4].slotId].itemId = -1;
        //    itemDataList[4].slotId--;
        //}
    }
    #endregion


    #region 아이템 초기화
    /// <summary>
    /// 슬롯 초기화 : 슬롯셋팅, 빈인벤아이템셋팅
    /// </summary>
    private void InitSlot()
    {
        GameObject slotPanel = GameObject.Find("SlotPanel");
        for (int i = 0; i < slotAmount; i++)
        {
            //슬롯오브젝트 추가
            Slot slot = Instantiate(inventorySlot, slotPanel.transform).GetComponent<Slot>();
            slot.slotId = i;
            slot.itemId = -1;
            slotList.Add(slot);
        }
    }

    /// <summary>
    /// 아이템 초기화 : 인벤에 있는 아이템들 셋팅
    /// </summary>
    private void InitItem()
    {
        for (int i = 0; i < database.db_InvenItem.Count; i++)
        {
            InvenItem invenItem = database.db_InvenItem[i];
            CreateItem(invenItem, i);
        }
    }
    #endregion



    #region 아이템 생성 / 추가
    /// <summary>
    /// 아이템 생성 / 추가
    /// </summary>
    /// <param name="itemData"></param>
    public void CreateOrAddItem(int itemId)
    {
        ItemData findItemData = itemDataList.FirstOrDefault(x => x.invenItem.itemId == itemId);
        if (findItemData == null)
        {   //해당아이템이 없다면 -> 새로추가
            CreateItem(new InvenItem(101, 10), slotList.FindIndex(x => x.itemId == -1));
        }
        else
        {   //만약 해당아이템이 있다면 -> 수량추가
            findItemData.leftStack++;  
        }
    }

    /// <summary>
    /// 아이템 생성
    /// </summary>
    /// <param name="invenItem">아이템종류</param>
    /// <param name="slotId">어떤슬롯에 추가될 것인지</param>
    private void CreateItem(InvenItem invenItem, int slotId)
    {
        ItemData itemData = Instantiate(inventoryItem).GetComponent<ItemData>();

        Slot slot = slotList[slotId];
        slot.itemId = invenItem.itemId;

        ItemType itemType = database.GetItemType(invenItem.itemId);
        itemData.name = "Item: " + itemType.title;

        itemData.SetItemData(slotId, invenItem);
        itemDataList.Add(itemData);
    }
    #endregion



    #region 아이템 정렬
    /// <summary>
    /// 아이템 정렬
    /// </summary>
    public void SortItem()
    {
        for (int i = 0; i < itemDataList.Count; i++)
        {
            SortRecursion(i);
        }
    }

    /// <summary>
    /// 아이템정렬 재귀함수
    /// </summary>
    /// <param name="idx"></param>
    private void SortRecursion(int idx)
    {
        ItemData itemData = itemDataList[idx];
        if(itemData.slotId == 0)
        {
            return;
        }    
        Slot prevSlot = slotList[itemData.slotId - 1];
        Slot curSlot = slotList[itemData.slotId];
        if (prevSlot != null && prevSlot.itemId == -1) //이전꺼가 아이템이 없으면
        {
            curSlot.itemId = -1; //현재꺼에 아이템 제거하고
            itemData.slotId--; //슬롯 한칸 앞으로
            SortRecursion(idx); //재귀함수
        }
    }
    #endregion



    #region 아이템 제거
    /// <summary>
    /// 아이템 제거
    /// </summary>
    /// <param name="itemData"></param>
    public void RemoveItem(ItemData itemData)
    {
        slotList[itemData.slotId].itemId = -1;
        itemDataList.Remove(itemData);
        Destroy(itemData.gameObject);
        SortItem();
    }
    #endregion
}