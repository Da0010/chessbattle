using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angleshougi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform myTransform = this.transform;

        // ワールド座標を基準に、回転を取得
        Vector3 worldAngle = myTransform.eulerAngles;
        worldAngle.x = -5.0f; // ワールド座標を基準に、z軸を軸にした回転を10度に変更
        myTransform.eulerAngles = worldAngle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
