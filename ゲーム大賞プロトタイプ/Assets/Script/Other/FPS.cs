using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake() // Start()よりも早く呼び出す
    {
        Application.targetFrameRate = 60; // フレームレートを60FPSで固定する
    }
}
