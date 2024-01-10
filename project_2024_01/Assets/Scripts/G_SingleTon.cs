using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class G_SingleTon : GenericSingleTon<G_SingleTon>
{
    //public Text text;
    public TMP_Text tmp_text;                    // TMP Text 선언
    public int playerScore = 0;
    public int playerScoreMax = 100;
    public Slider mainSlider;           
    public void AddScore(int amount){
        playerScore += amount;
        tmp_text.text = playerScore.ToString();  // playerScore는 int이기 때문에 문자열로 변환
        mainSlider.value = (float)playerScore / (float)playerScoreMax;  // Slider의 값을 반영할 때
    }

    public void SubmitSliderValue(){                  // Slider에서 값을 가져올 때
        tmp_text.text = mainSlider.value.ToString();
    }

    public void Start(){
        //text.text = "Legacy";
        tmp_text.text = "TMP";
    }
}
