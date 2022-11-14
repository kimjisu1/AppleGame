//using System;
//using UnityEngine;
//using UnityEngine.EventSystems;

///// <summary>
///// 아이템에 달아주는 클래스
///// </summary>
//public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
//{
//	public Item item;
//	public int amount;
//	public int slotId;

//	private Inventory inv;
//	private Tooltip tooltip;
//	private Vector2 offset;

//	void Start()
//	{
//		inv = GameObject.Find("Inventory").GetComponent<Inventory>();
//		tooltip = inv.GetComponent<Tooltip>();
//	}

//	public void OnBeginDrag(PointerEventData eventData)
//	{
//		if (item != null)
//		{
//			this.transform.SetParent(this.transform.parent.parent);
//			this.transform.position = eventData.position - offset;
//			GetComponent<CanvasGroup>().blocksRaycasts = false;
//		}
//	}

//	public void OnDrag(PointerEventData eventData)
//	{
//		if (item != null)
//		{
//			this.transform.position = eventData.position - offset;
//		}
//	}

//	public void OnEndDrag(PointerEventData eventData)
//	{
//		this.transform.SetParent(inv.slots[slotId].transform);
//		this.transform.position = inv.slots[slotId].transform.position;
//		GetComponent<CanvasGroup>().blocksRaycasts = true;
//	}

//	public void OnPointerDown(PointerEventData eventData)
//	{
//		offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
//	}

//	public void OnPointerEnter(PointerEventData eventData)
//	{
//		tooltip.Activate(item);
//	}

//	public void OnPointerExit(PointerEventData eventData)
//	{
//		tooltip.Deactivate();
//	}
//}



//using System;
//using System.Collections;
//using System.Linq;
//using TMPro;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

///// <summary>
///// 아이템에 달아주는 클래스
///// </summary>
//public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerClickHandler
//{
//	[HideInInspector] public int slotId;

//	//public ItemType itemType; //아이템타입과
//	[HideInInspector] public InvenItem invenItem; //인벤토리
//	public int leftStack
//    {
//		get => _leftStack;
//		set
//        {
//			_leftStack = value;
//			txt_Stack.text = _leftStack.ToString();
//		}
//    }
//    private int _leftStack;

//	private Coroutine coroutine;

//	[HideInInspector] public bool holding;
//	[HideInInspector] public bool draging;
//	[HideInInspector] public bool dragged;

//	public enum eItemState
//	{
//		idle,
//		press,
//		hold,
//		drag,
//	}
//	public eItemState _itemState;
//	private eItemState itemState
//    {
//        get { return _itemState; }
//        set { _itemState = value;
//            switch (value)
//            {
//                case eItemState.idle:
//                    {
//						//draging = true;
//						this.transform.SetParent(this.transform.parent.parent);
//						this.transform.position = eventData.position - offset;
//						GetComponent<CanvasGroup>().blocksRaycasts = false;
//					}
//                    break;
//                case eItemState.press:
//                    break;
//                case eItemState.hold:
//                    break;
//                case eItemState.drag:
//                    break;
//                default:
//                    break;
//            }
//        }
//    }

//	public Text txt_Stack;

//	private Inventory inv;
//	private Tooltip tooltip;
//	private Vector2 offset;

//	[HideInInspector] public ItemDatabase database;

//	void Start()
//	{
//		inv = GameObject.Find("Inventory").GetComponent<Inventory>();
//		txt_Stack = transform.GetComponentInChildren<Text>();
//		tooltip = inv.GetComponent<Tooltip>();
//	}
//	/// <summary>
//	/// 누른상태에서 드래그 시작할때
//	/// </summary>
//	/// <param name="eventData"></param>
//	public void OnBeginDrag(PointerEventData eventData)
//	{
//		GameObject.Find("Scroll View").GetComponent<Test_ScrollRect>().OnBeginDrag(eventData);
//		//dragged = true;
//		if (itemState == eItemState.press)
//		{
//			StopHolding();
//			return;
//		}
//		itemState = eItemState.drag;
//		//draging = true;

//		this.transform.SetParent(this.transform.parent.parent);
//		this.transform.position = eventData.position - offset;
//		GetComponent<CanvasGroup>().blocksRaycasts = false;

//	}



//	/// <summary>
//	/// 누른상태에서 드래그 중일때
//	/// </summary>
//	/// <param name="eventData"></param>
//    public void OnDrag(PointerEventData eventData)
//	{
//		//if(!holding) GameObject.Find("Scroll View").GetComponent<Test_ScrollRect>().OnDrag(eventData);
//		//if (!holding || !draging)
//		//      {
//		//          return;
//		//}
//		if (itemState != eItemState.drag)
//		{
//			GameObject.Find("Scroll View").GetComponent<Test_ScrollRect>().OnDrag(eventData);
//			return;
//		}
//		if (database.GetInvenItem(invenItem.itemId) != null)
//        {
//            this.transform.position = eventData.position - offset;
//		}
//	}


//	/// <summary>
//	/// 누른상태에서 드래그 끊났을때
//	/// </summary>
//	/// <param name="eventData"></param>
//	public void OnEndDrag(PointerEventData eventData)
//	{

//		//dragged = false;
//		//if (!draging)
//		//      {
//		//	return;
//		//      }
//		//draging = false;

//		if (itemState != eItemState.drag)
//		{
//			GameObject.Find("Scroll View").GetComponent<Test_ScrollRect>().OnEndDrag(eventData);
//			return;
//		}
//		itemState = eItemState.idle;

//		this.transform.SetParent(inv.slotList[slotId].transform);
//		this.transform.position = inv.slotList[slotId].transform.position;
//		GetComponent<CanvasGroup>().blocksRaycasts = true;
//	}

//	/// <summary>
//	/// 누른상태, 0.2초 지속해야 누른것으로 인정
//	/// </summary>
//	/// <param name="eventData"></param>
//	public void OnPointerDown(PointerEventData eventData)
//	{
//		offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);

//		StopHolding();
//		StartHolding();
//	}

//	void StartHolding()
//	{
//		coroutine = StartCoroutine(Co_StartHolding());
//	}
//	private IEnumerator Co_StartHolding()
//	{
//		itemState = eItemState.press;
//		holding = false;
//		GetComponent<RectTransform>().localScale = Vector3.one * 0.9f;

//		float curTime = 0f;
//		float durTime = 0.3f;
//		while (curTime < 1f)
//        {
//			//if (draging)
//			//{
//			//	yield break;
//			//}
//			if (itemState != eItemState.press)
//			{
//				yield break;
//			}
//			curTime += Time.deltaTime / durTime;
//			yield return null;
//		}

//		itemState = eItemState.hold;
//		holding = true;
//		GetComponent<RectTransform>().localScale = Vector3.one * 1.1f;

//		GetComponent<CanvasGroup>().alpha = 0.5f;
//	}

//	private void StopHolding()
//	{
//		if (coroutine != null)
//		{
//			StopCoroutine(coroutine);
//		}
//		itemState = eItemState.idle;
//		holding = false;
//		GetComponent<CanvasGroup>().alpha = 1f;
//		GetComponent<RectTransform>().localScale = Vector3.one * 1f;
//	}

//	/// <summary>
//	/// 뗀상태, 레이캐스트 끊겨도 유지됨
//	/// </summary>
//	/// <param name="eventData"></param>
//	public void OnPointerUp(PointerEventData eventData)
//	{
//		StopHolding();
//	}

//	public void OnPointerEnter(PointerEventData eventData)
//	{
//		tooltip.Activate(database.GetItemType(invenItem.itemId));
//	}

//	/// <summary>
//	/// 벗어난 상태, 레이캐스트 끊겨도 벗어난 상태가 될수 있다.
//	/// </summary>
//	/// <param name="eventData"></param>
//	public void OnPointerExit(PointerEventData eventData)
//    {
//        tooltip.Deactivate();
//        if (!draging) 
//		{
//			StopHolding();
//		}

//	}

//    public void OnPointerClick(PointerEventData eventData)
//    {
//		if (!holding && !dragged)
//		{
//			ItemData droppedItem = eventData.pointerClick.GetComponent<ItemData>();
//			droppedItem.leftStack--;
//		}
//	}
//}































using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 아이템에 달아주는 클래스
/// </summary>
public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerClickHandler
{
    public int slotId
    {
        get => _slotId;
        set
        {
            _slotId = value;
            Slot slot = inv.slotList[slotId];
            transform.SetParent(slot.transform, false);
            slot.itemId = invenItem.itemId;
        }
    }
    private int _slotId;

    //public ItemType itemType; //아이템타입과
    [HideInInspector] public InvenItem invenItem; //인벤토리


   
    private int _leftStack;
    public int leftStack
    {
        get => _leftStack;
        set
        {
            _leftStack = value;
            stackk = value;
            if (value == 0)
            {
                inv.RemoveItem(slotId);
                Destroy(gameObject);
            }
            txt_Stack.text = _leftStack.ToString();
        }
    }
    public int stackk;

    private Coroutine coroutine;

    public enum eItemState
    {
        idle, //기본상태
        press, //누른상태
        hold, //길게눌러서 홀드한 상태
        move, //길게눌러 홀드한 상태에서 이동
        drag, //길게누르지않고 드래그
    }
    private eItemState _itemState;
    public eItemState itemState
    {
        get { return _itemState; }
        set
        {
            _itemState = value;
            //Debug.Log("itemState: " + itemState);
            switch (value)
            {
                case eItemState.idle:
                case eItemState.drag:
                    {
                        GetComponent<RectTransform>().localScale = Vector3.one * 1f;
                        GetComponent<CanvasGroup>().alpha = 1f;
                        StopPress();
                    }
                    break;
                case eItemState.press:
                    {
                        GetComponent<RectTransform>().localScale = Vector3.one * 0.9f;
                        GetComponent<CanvasGroup>().alpha = 1f;
                        StartPress();
                    }
                    break;
                case eItemState.hold:
                case eItemState.move:
                    {
                        GetComponent<RectTransform>().localScale = Vector3.one * 1.1f;
                        GetComponent<CanvasGroup>().alpha = 0.5f;
                    }
                    break;
                default:
                    break;
            }
        }
    }


    public Text txt_Stack;
    private Inventory inv;
    private Tooltip tooltip;
    private Vector2 offset;

    private ItemDatabase database;

    void Start()
    {
        database = ItemDatabase.instance;
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        tooltip = inv.GetComponent<Tooltip>();
    }

    public void SetItemData(int slotId, InvenItem invenItem)
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        this.invenItem = invenItem;
        this.slotId = slotId;
        leftStack = this.invenItem.stack;
        transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Items/" + ItemDatabase.instance.db_ItemType[invenItem.itemId].slug);
    }

    /// <summary>
    /// 누른상태에서 드래그 시작할때
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {

        if (itemState == eItemState.press)
        {
            GameObject.Find("Scroll View").GetComponent<Test_ScrollRect>().OnBeginDrag(eventData);
            itemState = eItemState.drag;
            return;
        }
        itemState = eItemState.move;

        this.transform.SetParent(this.transform.parent.parent);
        this.transform.position = eventData.position - offset;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }



    /// <summary>
    /// 누른상태에서 드래그 중일때
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        if (itemState != eItemState.move)
        {
            GameObject.Find("Scroll View").GetComponent<Test_ScrollRect>().OnDrag(eventData);
            return;
        }
        if (database.GetInvenItem(invenItem.itemId) != null)
        {
            this.transform.position = eventData.position - offset;
        }
    }


    /// <summary>
    /// 누른상태에서 드래그 끊났을때
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (itemState != eItemState.move)
        {
            GameObject.Find("Scroll View").GetComponent<Test_ScrollRect>().OnEndDrag(eventData);
            return;
        }
        itemState = eItemState.idle;

        this.transform.SetParent(inv.slotList[slotId].transform);
        this.transform.position = inv.slotList[slotId].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    /// <summary>
    /// 누른상태, 0.2초 지속해야 누른것으로 인정
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        itemState = eItemState.press;

        offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
    }

    void StartPress()
    {
        coroutine = StartCoroutine(Co_StartHolding());
    }
    private IEnumerator Co_StartHolding()
    {
        float curTime = 0f;
        float durTime = 0.3f;
        while (curTime < 1f)
        {
            curTime += Time.deltaTime / durTime;
            if (itemState != eItemState.press)
            {
                yield break;
            }
            yield return null;
        }

        itemState = eItemState.hold;
    }

    private void StopPress()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    /// <summary>
    /// 뗀상태, 레이캐스트 끊겨도 유지됨
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        if (itemState == eItemState.press) //클릭시
        {
            itemState = eItemState.idle;
            leftStack--;
        }
        if(itemState == eItemState.hold)
        {
            itemState = eItemState.idle;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("invenItem.itemId: " + invenItem.itemId);
        tooltip.Activate(database.GetItemType(invenItem.itemId));
    }

    /// <summary>
    /// 벗어난 상태, 레이캐스트 끊겨도 벗어난 상태가 될수 있다.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
