using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject Player;
    private Player player;
    private Vector3 CameraPosition;
    private float OffsetY; // Y視点の補正

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        OffsetY = 5.1f;
        FindObject();
        FindScript();
    }

    // Update is called once per frame
    void Update()
    {
        CameraPosition = Player.transform.position; // プレイヤーのポジションを代入
        SetCameraWorkX();
        SetCameraWorkY();
        transform.position = new Vector3(CameraPosition.x, CameraPosition.y + OffsetY, transform.position.z);
    }

    // ↓↓↓ ヘルパー関数 ↓↓↓
    // オブジェクトの取得
    private void FindObject()
    {
        Player = GameObject.Find("Player");
    }

    // スクリプトの取得
    private void FindScript()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // X座標のカメラワーク
    private void SetCameraWorkX()
    {
        // X座標 (左-8.2f,右8.2f)
        if (Player.transform.position.x < -8.2f)
        {
            CameraPosition.x = -8.2f;
        }
        if (Player.transform.position.x > 8.2f)
        {
            CameraPosition.x = 8.2f;
        }
    }

    // Y座標のカメラワーク
    private void SetCameraWorkY()
    {
     
    }
}
