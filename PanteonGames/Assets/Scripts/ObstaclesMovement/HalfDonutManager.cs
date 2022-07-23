using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;


public class HalfDonutManager : MonoBehaviour
{
   [SerializeField] private float time = 0;
   [SerializeField] private float counter = 0;
   [SerializeField] private GameObject[] halfDonuts;

   private void FixedUpdate()
   {
      
      
      if (counter>=time && UIManager.instance.isGameStart)
      {
         time = Random.Range(3f, 10f);
         counter = 0;
         foreach (var item in halfDonuts)
         {
            item.GetComponent<HalfDonut>().HalfDonutMovement();
         }
      }
      counter += Time.deltaTime;

   }
}
