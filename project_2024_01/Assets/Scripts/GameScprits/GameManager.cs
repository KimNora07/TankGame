using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // 간단한 싱글톤 화

    public enum GAMESTATION : int{
        READY,
        PLAY = 10,
        STOP,
        LEVELUP = 20,
        END = 30
    }

    // 플레이어 데이터
    public int currentHp = 100;
    public int level = 1;
    public int[] levelExp = new int[30];  // 30렙 까지 설정
    public int currentExp = 0;

    // 플레이어 업그레이드 요소
    public int maxHp = 100;
    public float moveSpeed = 10.0f;
    public float fireSpeed = 4.0f;
    public int playerPower = 1;

    public GAMESTATION gameStation = GAMESTATION.READY;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void HpLevelUp(){
        maxHp += 10;
        GameUIManager.Instance.levelUpPanel_OnOFF(false);
        gameStation = GAMESTATION.PLAY;
    }
    public void MoveSpeedUp(){
        moveSpeed += 0.1f;
        GameUIManager.Instance.levelUpPanel_OnOFF(false);
        gameStation = GAMESTATION.PLAY;
    }
    public void FireSpeedUp(){
        fireSpeed += 0.5f;
        GameUIManager.Instance.levelUpPanel_OnOFF(false);
        gameStation = GAMESTATION.PLAY;
    }
    public void PowerLevelUp(){
        playerPower += 1;
        GameUIManager.Instance.levelUpPanel_OnOFF(false);
        gameStation = GAMESTATION.PLAY;
    }

    public void Start(){
        GameUIManager.Instance.levelUpPanel_OnOFF(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GamePlay(){
        gameStation = GAMESTATION.PLAY;
    }
    public void GamePlayStop(){
        gameStation = GAMESTATION.STOP;
    }
    public void GamePlayLevelUp(){
        gameStation = GAMESTATION.LEVELUP;
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
            GameUIManager.Instance.levelUpPanel_OnOFF(true);
            gameStation = GAMESTATION.LEVELUP;
        } 
    }
}
