using Fengj.GSessions;
using System;
using System.Collections;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public Camera mapCamera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMapCameraPosition();
    }

    private void UpdateMapCameraPosition()
    {
        //当鼠标在屏幕边界，移动地图
        var offsetPos = mapCamera.ScreenToViewportPoint(Input.mousePosition);
        if (offsetPos.x < 0.01 || offsetPos.y < 0.01 || offsetPos.x >= 0.99f || offsetPos.y >= 0.99f)
        {
            if (offsetPos.x < 0 || offsetPos.y < 0)
            {
                return;
            }

            Vector3 move = (offsetPos - new Vector3(0.5f, 0.5f)) * 0.1f;

            mapCamera.transform.position += move;
        }

        //当鼠标滚轮转动,放大缩小地图
        var scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if(scrollWheel != 0)
        {
            mapCamera.orthographicSize -= scrollWheel;
        }
    }
}