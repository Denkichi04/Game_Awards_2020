using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 移動タイプ
    private enum Type
    {
        IDOL,  // デフォルトとき
        JUMP,　// ジャンプしているとき
        LEFT,  // 左に移動
        RIGHT　// 右に移動
    }

    // フィールド変数
    private Rigidbody rb;
    private bool JumpFlag;  // ジャンプしているかどうか判定
    private bool MoveFlag;  // 移動しているかどうか判定
 
    // シリアライゼーション
    [SerializeField]
    private float Jump;      // ジャンプ値

    // Start is called before the first frame update
    void Start()
    {
        rb = this.transform.GetComponent<Rigidbody>();
        JumpFlag = false;
        MoveFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        ControllerAction(); // コントローラー入力処理
    }

    // ブロックとの当たり判定
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Block": // ブロックタグに当たったとき
                JumpFlag = false;
                Move(Type.IDOL);
                break;
        }
    }

    // ↓↓↓ ヘルパー関数 ↓↓↓
    // コントローラーの入力アクション
    private void ControllerAction()
    {
        //  スペースキー or Xbox360Bボタン && JumpFlagがfalse でジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && JumpFlag == false || Input.GetKeyDown("joystick button 1") && JumpFlag == false)
        {
            JumpFlag = true;
            Move(Type.JUMP);
        }
        // 左移動
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxisRaw("Horizontal") < 0)
        {
            Move(Type.LEFT);
        }
        // 右移動
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxisRaw("Horizontal") > 0)
        {
            Move(Type.RIGHT);
        }
    }

    // プレイヤーの移動処理
    private void Move(Type Set)
    {
        switch (Set)
        {
            case Type.IDOL:
                rb.velocity = new Vector3(0.0f, Jump, 0.0f);
                MoveFlag = false;
                break;
            case Type.JUMP:
                rb.velocity = new Vector3(0.0f, Jump * 2.0f, 0.0f);
                MoveFlag = true;
                break;
            case Type.LEFT:
                transform.Translate(-0.1f, 0f, 0f);
                break;
            case Type.RIGHT:
                transform.Translate(0.1f, 0f, 0f);
                break;
        }

    }

    // ↓↓↓ゲッター ↓↓↓
    public bool GetMoveFlag()
    {
        return MoveFlag;
    }
}

/*
Buttons(Key or Mouse Button)
joystick button 0 = A
joystick button 1 = B
joystick button 2 = X
joystick button 3 = Y
joystick button 4 = L
joystick button 5 = R
joystick button 6 = Back
joystick button 7 = Home
joystick button 8 = Left analog press
joystick button 9 = Right analog press

Axis(Joystick Axis)
X axis = Left analog X
Y axis = Left analog Y
3rd axis = LT / RT
4th axis = Right analog X
5th axis = Right analog Y
6th axis = Dpad X
7th axis = Dpad Y
*/