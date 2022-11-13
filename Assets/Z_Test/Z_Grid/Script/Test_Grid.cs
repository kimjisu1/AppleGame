//using Hypertonic.GridPlacement;
//using Hypertonic.GridPlacement.CustomSizing;
//using Hypertonic.GridPlacement.Example.BasicDemo;
//using Hypertonic.GridPlacement.Models;
//using System.Collections;
//using System.Collections.Generic;
//using System.Reflection;
//using UnityEngine;
//using UnityEngine.UI;

//public class Test_Grid : MonoBehaviour
//{
//    public GameObject[] prefabs;
//    public GameObject pivot;
//    public GameObject cover;
//    public Image inMove;
//    public GameObject outMove;
//    private GameObject curObj;
//    public GridManager gridManager;
//    private GridSaveManager gridSaveManager;
//    private void Start()
//    {
//        //gridManager = GetComponent<GridManager>();
//        gridManager.OnPlacementValidated += GridManager_OnPlacementValidated;

//        gridSaveManager = GetComponent<GridSaveManager>();
//    }


//    bool isValid;

//    private void GridManager_OnPlacementValidated(bool isValid)
//    {
//        this.isValid = isValid;
//    }

//    public void OnClick_Cover()
//    {
//        CurrentMethodName();
//        if (!isValid)
//        {
//            return;
//        }
//        cover.SetActive(false);
//        pivot.SetActive(false);
//        curObj = null;
//        gridManager.ConfirmPlacement();
//    }

//    public void OnClick_MoveDown()
//    {
//        CurrentMethodName();
//        inMove.raycastTarget = false;
//        outMove.SetActive(false);
//        cover.SetActive(false);
//    }
//    public void OnClick_MoveUp()
//    {
//        CurrentMethodName();
//        inMove.raycastTarget = true;
//        outMove.SetActive(true);
//        cover.SetActive(true);
//    }
//    public void OnClick_TurnRight()
//    {
//        CurrentMethodName();
//        HandleRotateRightPressed(curObj, 90);
//    }
//    public void OnClick_TurnLeft()
//    {
//        CurrentMethodName();
//        HandleRotateRightPressed(curObj, -90);
//    }
//    public void OnClick_Inven()
//    {
//        CurrentMethodName();
//        cover.SetActive(false);
//        pivot.SetActive(false);
//        curObj = null;
//        pivot.transform.SetParent(null);
//        gridManager.CancelPlacement();
//    }

//    private void CurrentMethodName()
//    {
//        return;
//        Debug.Log(MethodBase.GetCurrentMethod().Name);
//    }

//    private void OnGUI()
//    {   
//        if (curObj != null)
//        {
//            return;
//        }
//        for (int i = 0; i < prefabs.Length; i++)
//        {
//            if (GUI.Button(new Rect(i * 100, 0, 100, 100), i.ToString()))
//            {
//                GameObject obj = Instantiate(prefabs[i], gridManager.GetGridPosition(), new Quaternion());
//                obj.name = prefabs[i].name;
//                SelectObj(obj);
//            }
//        }
//    }

//    void SelectObj(GameObject obj)
//    {
//        cover.SetActive(true);
//        pivot.SetActive(true);
//        pivot.transform.SetParent(obj.transform);
//        pivot.transform.localPosition = Vector3.zero;
//        gridManager.EnterPlacementMode(obj);
//        curObj = obj;
//    }

//    private void HandleRotateRightPressed(GameObject obj, float rotateY)
//    {
//        obj.transform.Rotate(new Vector3(0, rotateY, 0));
//        gridManager.HandleGridObjectRotated();
//    }

//    public GameObject cameraRotateY;
//    public GameObject cameraPivotZ;
//    public float rotateSpeed;
//    public float zoomSpeed;
//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Alpha1))
//        {
//            gridSaveManager.HandleSaveGridObjectsPressed();
//        }
//        if (Input.GetKeyDown(KeyCode.Alpha2))
//        {
//            pivot.transform.SetParent(null);
//            Debug.Log("playPrefsSaveDataKey : " + PlayerPrefs.GetString("playPrefsSaveDataKey"));
//            gridSaveManager.HandleLoadGridObjectsPressed();
//        }
//        if (Input.GetKeyDown(KeyCode.Alpha3))
//        {
//            //gridManager.Setup();
//            GridManagerAccessor.RegisterGridManager("aa", gridManager);
//        }
//        if (Input.GetKeyDown(KeyCode.Alpha4))
//        {
//            GridManagerAccessor.UnregisterGridManager("aa", gridManager);
//        }
//        if (Input.GetKey(KeyCode.A))
//        {
//            cameraRotateY.transform.Rotate(Vector3.up * 360f * rotateSpeed * Time.deltaTime);
//        }
//        if (Input.GetKey(KeyCode.D))
//        {
//            cameraRotateY.transform.Rotate(Vector3.up * 360f * -rotateSpeed * Time.deltaTime);
//        }
//        if (Input.GetKey(KeyCode.W))
//        {
//            if(cameraPivotZ.transform.localPosition.z < 1f)
//            {
//                cameraPivotZ.transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
//            }
//        }
//        if (Input.GetKey(KeyCode.S))
//        {
//            if (cameraPivotZ.transform.localPosition.z > -1f)
//            {
//                cameraPivotZ.transform.Translate(-Vector3.forward * zoomSpeed * Time.deltaTime);
//            }
//        }
//        if (curObj != null)
//        {
//            return;
//        }
//        if (Input.GetMouseButtonDown(0))
//        {
//            Vector3 mousePosition = Input.mousePosition;
//            Ray ray = Camera.main.ScreenPointToRay(mousePosition, Camera.MonoOrStereoscopicEye.Mono);
//            if (Physics.Raycast(ray, out RaycastHit hit))
//            {
//                if(hit.transform.GetComponent<GridHeightPositioner>() != null)
//                {
//                    SelectObj(hit.transform.gameObject);
//                }
//            }
//        }
//    }

//}



//using Hypertonic.GridPlacement;
//using Hypertonic.GridPlacement.CustomSizing;
//using Hypertonic.GridPlacement.Example.BasicDemo;
//using Hypertonic.GridPlacement.Models;
//using System.Collections;
//using System.Collections.Generic;
//using System.Reflection;
//using UnityEngine;
//using UnityEngine.UI;

//public class Test_Grid : MonoBehaviour
//{
//    public GameObject[] prefabs;
//    public GameObject cover;
//    public GameObject pivot;

//    public Image inMove;
//    public GameObject outMove;

//    private GameObject curObj;
//    private GridSaveManager_Custom gridSaveManager;
//    public GameObject cameraRotateY;
//    public GameObject cameraPivotZ;
//    public float rotateSpeed;
//    public float zoomSpeed;
//    private bool isValid;
//    private void Start()
//    {
//        //gridManager = GetComponent<GridManager>();
//        gridSaveManager = GetComponent<GridSaveManager_Custom>();
//    }


//    private void GridManager_OnPlacementValidated(bool isValid)
//    {
//        this.isValid = isValid;
//    }

//    public void OnClick_Cover()
//    {
//        CurrentMethodName();
//        if (!isValid)
//        {
//            return;
//        }
//        cover.SetActive(false);
//        pivot.SetActive(false);
//        curObj = null;
//        GridManagerAccessor.GridManager.ConfirmPlacement();
//    }

//    public void OnClick_MoveDown()
//    {
//        CurrentMethodName();
//        inMove.raycastTarget = false;
//        outMove.SetActive(false);
//        cover.SetActive(false);
//    }
//    public void OnClick_MoveUp()
//    {
//        CurrentMethodName();
//        inMove.raycastTarget = true;
//        outMove.SetActive(true);
//        cover.SetActive(true);
//    }
//    public void OnClick_TurnRight()
//    {
//        CurrentMethodName();
//        HandleRotateRightPressed(curObj, 90);
//    }
//    public void OnClick_TurnLeft()
//    {
//        CurrentMethodName();
//        HandleRotateRightPressed(curObj, -90);
//    }
//    public void OnClick_Inven()
//    {
//        CurrentMethodName();
//        cover.SetActive(false);
//        pivot.SetActive(false);
//        curObj = null;
//        pivot.transform.SetParent(null);
//        GridManagerAccessor.GridManager.CancelPlacement();
//    }

//    private void CurrentMethodName()
//    {
//        return;
//        Debug.Log(MethodBase.GetCurrentMethod().Name);
//    }

//    private void OnGUI()
//    {
//        if (curObj != null)
//        {
//            return;
//        }
//        for (int i = 0; i < prefabs.Length; i++)
//        {
//            if (GUI.Button(new Rect(i * 100, 0, 100, 100), i.ToString()))
//            {
//                GameObject obj = Instantiate(prefabs[i], GridManagerAccessor.GridManager.GetGridPosition(), new Quaternion());
//                obj.name = prefabs[i].name;
//                SelectObj(obj);
//            }
//        }
//    }

//    void SelectObj(GameObject obj)
//    {
//        cover.SetActive(true);
//        pivot.SetActive(true);
//        pivot.transform.SetParent(obj.transform);
//        pivot.transform.localPosition = Vector3.zero;
//        if (obj.TryGetComponent(out GridObjectInfo objectInfo))
//        {
//            SelectedGridManager(objectInfo.GridKey);
//        }
//        else if(obj.name == "GZ_footboard_02")
//        {
//            SelectedGridManager("BBB");
//        }
//        else
//        {
//            SelectedGridManager("AAA");
//        }

//        GridManagerAccessor.GridManager.EnterPlacementMode(obj);
//        curObj = obj;
//    }

//    private void HandleRotateRightPressed(GameObject obj, float rotateY)
//    {
//        obj.transform.Rotate(new Vector3(0, rotateY, 0));
//        GridManagerAccessor.GridManager.HandleGridObjectRotated();
//    }

//    void SelectedGridManager(string gridKey)
//    {
//        //Debug.Log("Select : " + gridKey);
//        GridManagerAccessor.GridManager.OnPlacementValidated -= GridManager_OnPlacementValidated;
//        GridManagerAccessor.SetSelectedGridManager(gridKey);
//        GridManagerAccessor.GridManager.OnPlacementValidated += GridManager_OnPlacementValidated;
//    }

//    private string[] strArr = new string[] { "AAA", "BBB" };

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Alpha1))
//        {
//            for (int i = 0; i < strArr.Length; i++)
//            {
//                gridSaveManager.HandleSaveGridObjectsPressed(strArr[i]);
//            }
//        }
//        if (Input.GetKeyDown(KeyCode.Alpha0))
//        {
//            pivot.transform.SetParent(null);
//            for (int i = 0; i < strArr.Length; i++)
//            {
//                SelectedGridManager(strArr[i]);
//                gridSaveManager.HandleLoadGridObjectsPressed(strArr[i]);
//            }
//        }

//        //if (Input.GetKeyDown(KeyCode.Alpha1))
//        //{
//        //    GridManagerAccessor.RegisterGridManager("AAA", GridManagerAccessor.GetGridManagerByKey("AAA"));
//        //}
//        //if (Input.GetKeyDown(KeyCode.Alpha2))
//        //{
//        //    GridManagerAccessor.RegisterGridManager("BBB", GridManagerAccessor.GetGridManagerByKey("BBB"));
//        //}


//        if (Input.GetKeyDown(KeyCode.Alpha3))
//        {
//            SelectedGridManager("AAA");
//        }
//        if (Input.GetKeyDown(KeyCode.Alpha4))
//        {
//            SelectedGridManager("BBB");
//        }
//        if (Input.GetKey(KeyCode.A))
//        {
//            cameraRotateY.transform.Rotate(Vector3.up * 360f * rotateSpeed * Time.deltaTime);
//        }
//        if (Input.GetKey(KeyCode.D))
//        {
//            cameraRotateY.transform.Rotate(Vector3.up * 360f * -rotateSpeed * Time.deltaTime);
//        }
//        if (Input.GetKey(KeyCode.W))
//        {
//            if (cameraPivotZ.transform.localPosition.z < 1f)
//            {
//                cameraPivotZ.transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
//            }
//        }
//        if (Input.GetKey(KeyCode.S))
//        {
//            if (cameraPivotZ.transform.localPosition.z > -1f)
//            {
//                cameraPivotZ.transform.Translate(-Vector3.forward * zoomSpeed * Time.deltaTime);
//            }
//        }
//        if (curObj != null)
//        {
//            return;
//        }
//        if (Input.GetMouseButtonDown(0))
//        {
//            Vector3 mousePosition = Input.mousePosition;
//            Ray ray = Camera.main.ScreenPointToRay(mousePosition, Camera.MonoOrStereoscopicEye.Mono);
//            if (Physics.Raycast(ray, out RaycastHit hit))
//            {
//                if (hit.transform.GetComponent<GridHeightPositioner>() != null)
//                {
//                    SelectObj(hit.transform.gameObject);
//                }
//            }
//        }
//    }

//}



















































using Hypertonic.GridPlacement;
using Hypertonic.GridPlacement.CustomSizing;
using Hypertonic.GridPlacement.Example.BasicDemo;
using Hypertonic.GridPlacement.Models;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Test_Grid : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject cover;
    public GameObject pivot;

    public Image inMove;
    public GameObject outMove;

    private GameObject curObj;
    private GridSaveManager_Custom gridSaveManager;
    public GameObject cameraRotateY;
    public GameObject cameraPivotZ;
    public float rotateSpeed;
    public float zoomSpeed;
    private bool isValid;
    private List<Texture2D> thumbnailList = new List<Texture2D>();

    private string[] strArr = new string[] { "AAA", "BBB" };


    /// <summary>
    /// 인벤시스템 구현하자..!!
    /// </summary>
    private void Start()
    {
        gridSaveManager = gameObject.AddComponent<GridSaveManager_Custom>();
        for (int i = 0; i < prefabs.Length; i++)
        {
            thumbnailList.Add(RuntimePreviewGenerator.GenerateModelPreview(prefabs[i].transform, 512, 512));
        }

    }


    private void GridManager_OnPlacementValidated(bool isValid)
    {
        this.isValid = isValid;
    }

    public void OnClick_Cover()
    {
        CurrentMethodName();
        if (!isValid)
        {
            return;
        }
        cover.SetActive(false);
        pivot.SetActive(false);
        curObj = null;
        GridManagerAccessor.GridManager.ConfirmPlacement();
    }

    public void OnClick_MoveDown()
    {
        CurrentMethodName();
        inMove.raycastTarget = false;
        outMove.SetActive(false);
        cover.SetActive(false);
    }
    public void OnClick_MoveUp()
    {
        CurrentMethodName();
        inMove.raycastTarget = true;
        outMove.SetActive(true);
        cover.SetActive(true);
    }
    public void OnClick_TurnRight()
    {
        CurrentMethodName();
        HandleRotate(curObj, 90);
    }
    public void OnClick_TurnLeft()
    {
        CurrentMethodName();
        HandleRotate(curObj, -90);
    }
    public void OnClick_Inven()
    {
        CurrentMethodName();
        cover.SetActive(false);
        pivot.SetActive(false);
        curObj = null;
        pivot.transform.SetParent(null);
        GridManagerAccessor.GridManager.CancelPlacement();
    }

    private void CurrentMethodName()
    {
        return;
        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }
    private void OnGUI()
    {
        if (curObj != null)
        {
            return;
        }
        for (int i = 0; i < prefabs.Length; i++)
        {
            if (GUI.Button(new Rect(i * 150, 0, 150, 150), new GUIContent(thumbnailList[i])))
            {

                GameObject obj = Instantiate(prefabs[i], GridManagerAccessor.GridManager.GetGridPosition(), new Quaternion());
                obj.name = prefabs[i].name;
                SelectObj(obj);
            }
        }
    }

    void SelectObj(GameObject obj)
    {
        cover.SetActive(true);

        pivot.SetActive(true);
        pivot.transform.SetParent(obj.transform);
        pivot.transform.localPosition = Vector3.zero;

        if (obj.TryGetComponent(out GridObjectInfo objectInfo))
        {
            SelectedGridManager(objectInfo.GridKey);
        }
        else if (obj.name == "GZ_footboard_02")
        {
            SelectedGridManager("BBB");
        }
        else
        {
            SelectedGridManager("AAA");
        }

        GridManagerAccessor.GridManager.EnterPlacementMode(obj);
        curObj = obj;
    }

    private void HandleRotate(GameObject obj, float rotateY)
    {
        obj.transform.Rotate(new Vector3(0, rotateY, 0));
        GridManagerAccessor.GridManager.HandleGridObjectRotated();
    }

    void SelectedGridManager(string gridKey)
    {
        //Debug.Log("Select : " + gridKey);
        GridManagerAccessor.GridManager.OnPlacementValidated -= GridManager_OnPlacementValidated;
        GridManagerAccessor.SetSelectedGridManager(gridKey);
        GridManagerAccessor.GridManager.OnPlacementValidated += GridManager_OnPlacementValidated;
    }

    void Save()
    {
        gridSaveManager.HandleSaveGridObjectsPressed(strArr);
    }
    void Load()
    {
        pivot.transform.SetParent(null);

        string saveDataAsJson = PlayerPrefs.GetString("GRIDMANAGER");
        _GridData _gridData = JsonUtility.FromJson<_GridData>(saveDataAsJson);

        for (int i = 0; i < _gridData._saveDatas.Count; i++)
        {
            SelectedGridManager(_gridData._saveDatas[i].gridId);
            gridSaveManager.HandleLoadGridObjectsPressed(_gridData._saveDatas[i]);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Load();
        }

        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    SelectedGridManager("AAA");
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    SelectedGridManager("BBB");
        //}


        if (Input.GetKey(KeyCode.A))
        {
            cameraRotateY.transform.Rotate(Vector3.up * 360f * rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cameraRotateY.transform.Rotate(Vector3.up * 360f * -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (cameraPivotZ.transform.localPosition.z < 1f)
            {
                cameraPivotZ.transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (cameraPivotZ.transform.localPosition.z > -1f)
            {
                cameraPivotZ.transform.Translate(-Vector3.forward * zoomSpeed * Time.deltaTime);
            }
        }
        if (curObj != null)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition, Camera.MonoOrStereoscopicEye.Mono);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.GetComponent<GridHeightPositioner>() != null)
                {
                    SelectObj(hit.transform.gameObject);
                }
            }
        }
    }
}
