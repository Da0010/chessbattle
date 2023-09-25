using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{
    
    public bool isAutoRotate = false; // 最初に自動で回転させておくかのフラグ
    public float minCameraAngleX = 310.0f; // カメラの最小角度
    public float maxCameraAngleX = 20.0f; // カメラの最大角度
    public float swipeTurnSpeed = 30.0f; // スワイプで回転するときの回転スピード
    public float autoRotateSpeed = 20.0f; // 自動で回転させるときの回転スピード

    private Vector3 baseMousePos; // 基準となるタップの座標
    private Vector3 baseCameraPos; // 基準となるカメラの座標
    private bool isMouseDown = false; // マウスが押されているかのフラグ


    void Start()
    {
    }

    void Update()
    {
        // 自動で回す
        if (isAutoRotate)
        {
            float angleY = this.transform.eulerAngles.y - Time.deltaTime * autoRotateSpeed;
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, angleY, 0);
        }

        // タップの種類の判定 & 対応処理
        if ((Input.touchCount == 1 && !isMouseDown) || Input.GetMouseButtonDown(0))
        {
            baseMousePos = Input.mousePosition;
            isMouseDown = true;
            isAutoRotate = false;
        }
        // 指離した時の処理
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }

        // スワイプ回転処理
        if (isMouseDown)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 distanceMousePos = (mousePos - baseMousePos);
            float angleX = this.transform.eulerAngles.x - distanceMousePos.y * swipeTurnSpeed * 0.01f;
            float angleY = this.transform.eulerAngles.y + distanceMousePos.x * swipeTurnSpeed * 0.01f;

            if ((angleX >= -10f && angleX <= maxCameraAngleX) || (angleX >= minCameraAngleX && angleX <= 370f))
            {
                this.transform.eulerAngles = new Vector3(angleX, angleY, 0);
            }
            else
            {
                this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, angleY, 0);
            }

            baseMousePos = mousePos;
        }
    }

    public void resetCamera(){
        this.transform.eulerAngles = new Vector3(12,180,0);
        this.transform.position = new Vector3(0,1.05f,0);
    }
}
