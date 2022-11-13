using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Test_땅따먹기 : MonoBehaviour
{
    public int[,] xy;
    public GameObject[] xyz;
    public GameObject[,] goXZ;
    List<Vector2> check = new List<Vector2>();
    public int range;
    GameObject prevObj;

    List<GameObject> rememberObj = new List<GameObject>();

    void Start()
    {
        xy = new int[3, 3];
        goXZ = new GameObject[60, 30];
        //Debug.Log("goXY.Length: " + goXZ.GetLength(0));
        int xLen = goXZ.GetLength(0);
        int zLen = goXZ.GetLength(1);
        for (int z = 0; z < zLen; z++)
        {
            for (int x = 0; x < xLen; x++)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.transform.position = new Vector3(x, 0, z);
                goXZ[x, z] = go;
                
            }
        }
        player = GameObject.CreatePrimitive(PrimitiveType.Cube);
        player.GetComponent<MeshRenderer>().material.color = Color.blue;
        player.transform.position = Vector3.up;

        System.Buffer.BlockCopy(goXZ, 0, xyz, 0, 16);
    }
    Vector2 oldPos;
    public GameObject player;
    public float speed = 5f;
    public float curTime;
    public float interval = 0.1f;
    void Update()
    {
        if(curTime < Time.time)
        {
            curTime = Time.time + interval;
            float xx = Input.GetAxisRaw("Horizontal") * speed;
            float zz = Input.GetAxisRaw("Vertical") * speed;
            player.transform.Translate(xx, 0, zz);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition, Camera.MonoOrStereoscopicEye.Mono);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {

                Vector2 newPos = new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.z);
                if (oldPos == newPos)
                {
                    return; 
                }
                oldPos = newPos;
                MeshRenderer mr = hit.collider.GetComponent<MeshRenderer>();
                if (mr.material.color!= Color.red)
                {
                    mr.material.color = Color.yellow;
                    check.Add(newPos);
                    if (rememberObj.Count > 0) rememberObj[rememberObj.Count - 1].GetComponent<MeshRenderer>().material.color = Color.red;
                    rememberObj.Add(hit.collider.gameObject);
                }
                else
                {
                    if (rememberObj.Count == 1 ||
                        rememberObj[rememberObj.Count - 2] == hit.collider.gameObject)
                    {
                        rememberObj[rememberObj.Count - 1].GetComponent<MeshRenderer>().material.color = Color.white;
                        rememberObj.RemoveAt(rememberObj.Count - 1);
                        if (rememberObj.Count > 0) rememberObj[rememberObj.Count - 1].GetComponent<MeshRenderer>().material.color = Color.yellow;
                    }
                    else
                    {
                        rememberObj[rememberObj.Count - 1].GetComponent<MeshRenderer>().material.color = Color.red;
                        FillRed();
                    }

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FillRed();
        }
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            int xLen = goXZ.GetLength(0);
            int zLen = goXZ.GetLength(1);
            for (int z = 0; z < zLen; z++)
            {
                for (int x = 0; x < xLen; x++)
                {
                    goXZ[x, z].GetComponent<MeshRenderer>().material.color = Color.white;
                }
            }
            check.Clear();
        }
    }

    void FillRed()
    {
        rememberObj.Clear();
        int xLen = goXZ.GetLength(0);
        int zLen = goXZ.GetLength(1);
        for (int z = 0; z < zLen; z++)
        {
            for (int x = 0; x < xLen; x++)
            {
                if (goXZ[x, z].GetComponent<MeshRenderer>().material.color != Color.red)
                {
                    if (IsInside(goXZ[x, z].transform.position, check))
                    {
                        goXZ[x, z].GetComponent<MeshRenderer>().material.color = Color.blue;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="B"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    bool IsInside(Vector3 B, List<Vector2> p)
    {
        //crosses는 점q와 오른쪽 반직선과 다각형과의 교점의 개수
        int crosses = 0;
        for (int i = 0; i < p.Count; i++)
        {
            int j = (i + 1) % p.Count;
            //점 B가 선분 (p[i], p[j])의 y좌표 사이에 있음
            if ((p[i].y > B.z) != (p[j].y > B.z))
            {
                //atX는 점 B를 지나는 수평선과 선분 (p[i], p[j])의 교점
                double atX = (p[j].x - p[i].x) * (B.z - p[i].y) / (p[j].y - p[i].y) + p[i].x;
                //atX가 오른쪽 반직선과의 교점이 맞으면 교점의 개수를 증가시킨다.
                if (B.x < atX)
                {
                    crosses++;
                }
            }
        }
        return crosses % 2 > 0;
    }

}
