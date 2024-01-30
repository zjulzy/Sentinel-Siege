using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 15f;
    public float panSpeed = 30f;
    public float panBorderThickness = 20f;

    public float scrollMax;
    public float scrollMin;
    

    // Update is called once per frame
    void Update()
    {
        // 处理按键输入
        if (Input.GetKey(KeyCode.W)||Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * (panSpeed * Time.deltaTime), Space.World);
        }
        if (Input.GetKey(KeyCode.S)||Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * (panSpeed * Time.deltaTime), Space.World);
        }
        if (Input.GetKey(KeyCode.A)||Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * (panSpeed * Time.deltaTime), Space.World);
        }
        if (Input.GetKey(KeyCode.D)||Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * (panSpeed * Time.deltaTime), Space.World);
        }
        
        // 处理scrollview缩放
        var pos = transform.position;
        pos.y -= Input.GetAxis("Mouse ScrollWheel")  *scrollSpeed;
        pos.y = Mathf.Clamp(pos.y, scrollMin, scrollMax);
        transform.position = pos;
    }
}
