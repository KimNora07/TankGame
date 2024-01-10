using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_SingleTon : GenericSingleTon<G_SingleTon>
{
    public int playerScore = 0;
    public void AddScore(int amount){
        playerScore += amount;
    }
}
