using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;


public class HalfDonut : MonoBehaviour
{
    [SerializeField] private GameObject movingStick;
    [SerializeField] private GameObject halfDonut;
    public float pos;
    
    private void Start()
    {
        DOTween.Init();
       
        pos = movingStick.transform.position.x;

    }

    public void HalfDonutMovement()
    {
        movingStick.transform.DOMoveX(halfDonut.transform.position.x, 3f);
        movingStick.transform.DOMoveX(pos, 2f, false).SetDelay(1f);
    }
}