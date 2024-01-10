using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenericContainerSample : MonoBehaviour
{
    private GenericContainer<int> intContainer;        // 제너릭 int로 선언
    private GenericContainer<string> stringContainer;  // 제너릭 string으로 선언
    // Start is called before the first frame update   // 또한 커스텀 클래스로 선언해서 사용 가능
    void Start()
    {
        intContainer = new GenericContainer<int>(5);
        stringContainer = new GenericContainer<string>(10);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){         // 1번 버튼을 눌렀을 경우
            intContainer.Add(Random.Range(0, 100));   // 0 ~ 99 까지  랜덤 숫자를 넣는다.
            DisplayContainerItems(intContainer);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            string randomString = "Item " + Random.Range(0, 100);  // 0 ~ 99 까지 랜덤 숫자를 넣는다. 예) Item 0
            stringContainer.Add(randomString);
            DisplayContainerItems(stringContainer);
        }
    }

    private void DisplayContainerItems<T>(GenericContainer<T> container){  // 제너릭으로 만든 배열을 보여주는 함수
        T[] Items = container.GetItems();              // 인수로 들어온 Items 제너릭 배열을 함수로 통해 가져온다
        string temp = "";                              // 임시로 사용할 string을 선언
 
        for(int i = 0; i < Items.Length; i++){         // 배열의 길이만큼 for문을 돈다
            if(Items[i] != null){                      // 배열에 데이터가 있을경우 string으로 변환
                temp += Items[i].ToString() + " - ";  
            }
            else{                                      // 배열에 데이터가 없을경우 Empty문자열로 변환
                temp += "Empty - ";
            }
        }
        Debug.Log(temp);
    }
}
