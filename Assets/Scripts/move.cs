using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public GameObject tatget;
    public int grid_w = 16, grid_h = 9;
    public int px = 1, py = 1;
    public GameObject poet, warrior, nurse, arch, magic;
     List<GameObject> torotate;
    float prvang = 90f,angle;
    // Start is called before the first frame update
    void Start()
    {
        poet = GameObject.Find("poet");
        warrior  = GameObject.Find("warrior");
        nurse = GameObject.Find("nurse");
        arch = GameObject.Find("arch");
        magic = GameObject.Find("magic");


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            py = Mathf.Max(1, py - 1);
            angle = 90 - prvang;
            prvang = 90;
            movefunction();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            py = Mathf.Min(grid_h-1, py + 1);
            angle = 270 - prvang;
            prvang = 270;
            movefunction();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            px = Mathf.Max(1, px - 1);
            angle = 180 - prvang;
            prvang = 180;
            movefunction();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            px = Mathf.Min(grid_w, px + 1);
            angle = 0 - prvang;
            prvang = 0;
            movefunction();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    void movefunction()
    {
     

        RotateAround(warrior, poet.transform.position, angle);
        RotateAround(nurse, poet.transform.position, angle);
        RotateAround(arch, poet.transform.position, angle);
        RotateAround(magic, poet.transform.position, angle);

        Vector3 dir = new Vector3(px*120+60,-py*120-60,0);
        gameObject.transform.GetComponent<RectTransform>().anchoredPosition= dir;
    }
    private void RotateAround(GameObject rotateobject,Vector3 center,  float angle)
    {
        //绕axis轴旋转angle角度
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //旋转之前,以center为起点,transform.position当前物体位置为终点的向量.
        Vector3 beforeVector = rotateobject.transform.position - center;
        //四元数 * 向量(不能调换位置, 否则发生编译错误)
        Vector3 afterVector = rotation * beforeVector;//旋转后的向量
        //向量的终点 = 向量的起点 + 向量
    
           rotateobject .transform.position = afterVector + center;
       
    }

}
