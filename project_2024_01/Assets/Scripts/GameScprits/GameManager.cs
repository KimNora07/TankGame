using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // 간단한 싱글톤 화

    public int maxHp = 100;
    public int currentHp = 100;
    public int level = 1;
    public int[] levelExp = new int[30];  // 30렙 까지 설정
    public int currentExp = 0;
    public float moveSpeed = 10.0f;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExpUp(int amount){
        if(level == levelExp.Length) return;  // 최대 레벨에 도달 했을 경우 그냥 리턴

        currentExp += amount;                 // 경험치를 올려준다.
        LevelUpCheck();
    }

    public void LevelUpCheck(){
        if(currentExp >= levelExp[level - 1]){
            currentExp -= levelExp[level - 1];
            level += 1;

            if(level >= levelExp.Length){
                level = levelExp.Length;
            }
        } 
    }
}
