using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField]
    private GameObject StartPanel;
    [SerializeField]
    private GameObject GamePanel;
    [SerializeField]
    private GameObject OverPanel;
    [SerializeField]
    private GameObject Buttons;

    [SerializeField]
    private TextMeshProUGUI _staminaPriceText;
    [SerializeField]
    private TextMeshProUGUI _staminaLevelText;

    [SerializeField]
    private TextMeshProUGUI _incomePriceText;
    [SerializeField]
    private TextMeshProUGUI _incomeLevelText;

    [SerializeField]
    private TextMeshProUGUI _speedPriceText;
    [SerializeField]
    private TextMeshProUGUI _speedLevelText;

    void Start()
    {
        SetSpecies();
    }

    void Update()
    {
        switch (gameManager.GameStatus)
        {
            case 0:
                StartPanel.SetActive(true);
                GamePanel.SetActive(false);
                OverPanel.SetActive(false);
                break;
            case 1:
                StartPanel.SetActive(false);
                GamePanel.SetActive(true);
                OverPanel.SetActive(false);
                break;
            case 2:
                StartPanel.SetActive(false);
                GamePanel.SetActive(false);
                OverPanel.SetActive(true);
                break;
        }

    }

    void SetSpecies()
    {
        int nextSellPrice = gameManager.playerMoney / 3;
        int randGap = Random.Range(3 , 10);

        _staminaPriceText.text = (nextSellPrice + Random.Range(0, randGap)).ToString();
        _staminaLevelText.text = "LVL " + gameManager.playerStaminaLvl;

        _incomePriceText.text = (nextSellPrice + Random.Range(0, randGap)).ToString();
        _incomeLevelText.text = "LVL " + gameManager.playerIncomeLvl;

        _speedPriceText.text = (nextSellPrice + Random.Range(0, randGap)).ToString();
        _speedLevelText.text = "LVL " + gameManager.playerSpeedLvl;

    }

    public void OnButtonDown(string ButtonName)
    {
        switch (ButtonName)
        {
            case "GameStart":
                gameManager.GameStatus = 1;
                break;

            case "StaminaUp":
                break;

            case "IncomeUp":
                break;

            case "SpeedUp":
                break;
        }
    }
}