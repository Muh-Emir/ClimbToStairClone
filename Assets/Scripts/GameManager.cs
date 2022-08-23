using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int GameStatus;

    public int playerMoney;
    public int playerStaminaLvl;
    public int playerIncomeLvl;
    public int playerSpeedLvl;

    void Awake()
    {
        GameStatus = 0;
    }

    void Update()
    {
        
    }
}
