using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SingleTon.Instance.AddScore(10);  // 싱글톤 클래스 Instance에 접근하여 함수 호출
        G_SingleTon.Instance.AddScore(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
