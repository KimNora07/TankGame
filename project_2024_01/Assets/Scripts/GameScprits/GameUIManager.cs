using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Slider slider_Player_Hp_Bar;
    public Slider slider_Player_Exp_Bar;
    public TMP_Text tmptext_Player_Hp;
    public TMP_Text tmptext_Player_Exp;
    public TMP_Text tmptext_Player_Level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider_Player_Hp_Bar.value = (float)GameManager.Instance.currentHp / 
                                     (float)GameManager.Instance.maxHp;
        slider_Player_Exp_Bar.value = (float)GameManager.Instance.currentExp / 
                                      (float)GameManager.Instance.levelExp[GameManager.Instance.level - 1];  // level은 1부터 시작하기 때문에 -1을 한다
        tmptext_Player_Hp.text = "Hp : " + GameManager.Instance.currentHp.ToString();
        tmptext_Player_Exp.text = "Exp : " + GameManager.Instance.currentExp.ToString();
        tmptext_Player_Level.text = "Level : " + GameManager.Instance.level.ToString();
    }
}
