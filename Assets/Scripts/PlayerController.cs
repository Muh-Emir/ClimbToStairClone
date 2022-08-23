using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField]
    private GameObject PlayerMesh;

    [SerializeField]
    private GameObject stairCenter;

    [SerializeField]
    private float PlayerSpeed;
    [SerializeField]
    private float tweenTime;

    [SerializeField]
    private bool isClick;
    [SerializeField]
    private bool isMove;

    [SerializeField]
    private int stepCount;

    [SerializeField]
    private int spawnLength;

    [SerializeField]
    private bool maxTired;
    [SerializeField]
    private float playerTired;
    [SerializeField]
    private float playerMaxTired;
    [SerializeField]
    private float playerOverTired;
    [SerializeField]
    private float playerCooling;
    [SerializeField]
    private float playerStamina;

    public float playerRed;

    void Start()
    {
        
    }

    void Update()
    {
        if (gameManager.GameStatus == 1)
            PlayerLook();
        
        if (Input.GetMouseButtonDown(0) && gameManager.GameStatus == 1)
        {
            isClick = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isClick = false;
        }

        if (isClick && !isMove)
        {
            TiredSystem();
            PlayerMove();
            transform.GetChild(0).GetComponent<PlayerAnimator>().AnimType("StairRun");
        }
        else if(!isClick && !isMove && !maxTired && playerTired > 0)
        {
            transform.GetChild(0).GetComponent<PlayerAnimator>().AnimType("StairIdle");
        }
        else if (!isClick && !isMove && maxTired && playerTired > playerMaxTired)
        {
            playerTired -= Time.deltaTime * playerCooling;
            transform.GetChild(0).GetComponent<PlayerAnimator>().AnimType("StairIdle2");
        }
        if (playerTired >= playerOverTired)
        {
            Debug.Log("GameOver");
            gameManager.GameStatus = 2;
        }
        if (playerTired > playerMaxTired)
        {
            playerRed = (playerTired - playerMaxTired) / (playerOverTired - playerMaxTired);
            PlayerMesh.GetComponent<SkinnedMeshRenderer>().material.color = new Color(1, 1 - playerRed, 1 - playerRed);
        }
    }

    void PlayerLook()
    {
        transform.LookAt(new Vector3(stairCenter.transform.position.x, transform.position.y, stairCenter.transform.position.z));
    }

    void PlayerMove()
    {
        isMove = true;

        stairCenter.GetComponent<StairCenter>().CreateStair(spawnLength);
        GameObject lastStair = stairCenter.GetComponent<StairCenter>().stairList[stepCount];
        GameObject stairStep = lastStair.transform.GetChild(2).gameObject;

        transform.DOMove(stairStep.transform.position, tweenTime / PlayerSpeed).OnComplete(() => isMove = false);
        stepCount++;

    }

    void TiredSystem()
    {
        playerTired += Time.deltaTime * (10 / playerStamina);
        if (playerTired > playerMaxTired)
        {
            playerRed = Mathf.Clamp(playerTired - playerMaxTired, playerMaxTired, playerOverTired);
        }

        if (playerTired > playerMaxTired)
        {
            maxTired = true;
        }
    }
}