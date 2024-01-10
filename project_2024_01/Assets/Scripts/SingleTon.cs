using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon : MonoBehaviour
{
    public static SingleTon Instance{ get; private set; }  // static을 사용해서 Instance 등록
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null){
            Instance = this;                // this는 자신의 class를 return 한다
            DontDestroyOnLoad(gameObject);  // MonoBehaviour 동작을 위해 GameObject에 소스를 넣고 파괴 되지 않게 하기 위해 선언
                                            // DontDestroyOnLoad 함수를 사용하여 오브젝트가 파괴 되지 않게 한다.
        }
        else{
            Destroy(gameObject);            // 만약 같은 싱글톤 클래스가 인스턴스 되어있으면 해당 오브젝트를 파괴 한다.
        }
    }

    public int playerScore = 0;
    public void AddScore(int amount){
        playerScore += amount;
    }
}
