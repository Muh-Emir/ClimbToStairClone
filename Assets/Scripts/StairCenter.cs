using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StairCenter : MonoBehaviour
{
    [SerializeField]
    private GameObject _stairPref;

    public List<GameObject> stairList;

    [SerializeField]
    private float _stairHeight;
    [SerializeField]
    private float _stairAngle;

    [SerializeField]
    private float _cylinderScaleTween;
    [SerializeField]
    private float _stairScaleTween;

    void Start()
    {
        CreateStair(1);
    }

    void Update()
    {

    }

    public void CreateStair(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject stair = Instantiate(_stairPref, transform);

            stair.transform.position = new Vector3(0, stairList.Count * _stairHeight, 0);

            stair.transform.localEulerAngles = new Vector3(0, stairList.Count * _stairAngle, 0);

            stairList.Add(stair);

            stair.transform.GetChild(0).transform.DOScale(Vector3.one, _cylinderScaleTween).SetEase(Ease.InOutBack);
            stair.transform.GetChild(1).transform.DOScale(Vector3.one, _stairScaleTween).SetEase(Ease.InOutBack);
        }
    }
}