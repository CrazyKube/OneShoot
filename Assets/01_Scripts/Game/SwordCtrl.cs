using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCtrl : MonoBehaviour {
    public float swordX;
    public float handX;
    public float weaponX;
    //public float footX;
    //public Transform footTr;
    public Transform swordTr;
    public Transform handTr;
    public Transform weaponTr;
    private Vector3 screenPosition;//将物体从世界坐标转换为屏幕坐标
    private Vector3 mousePositionOnScreen;//获取到点击屏幕的屏幕坐标
    private Vector3 mousePositionInWorld;//将点击屏幕的屏幕坐标转换为世界坐标
    void Update()
    {
        MouseFollow();
    }
    void MouseFollow()
    {
        //获取鼠标在相机中（世界中）的位置，转换为屏幕坐标；
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //获取鼠标在场景中坐标
        mousePositionOnScreen = Input.mousePosition;
        //让场景中的Z=鼠标坐标的Z
        mousePositionOnScreen.z = screenPosition.z;
        //将相机中的坐标转化为世界坐标
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        //物体跟随鼠标移动
        swordTr.position = mousePositionInWorld;
        //物体跟随鼠标X轴移动
        swordTr.position = new Vector3(mousePositionInWorld.x+swordX, swordTr.position.y, swordTr.position.z);
        //物体跟随鼠标移动
        handTr.position = mousePositionInWorld;
        //物体跟随鼠标X轴移动
        handTr.position = new Vector3(mousePositionInWorld.x+handX, handTr.position.y, handTr.position.z);
        
    }
}
