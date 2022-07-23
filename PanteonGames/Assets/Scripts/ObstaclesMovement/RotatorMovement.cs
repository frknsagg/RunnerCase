using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorMovement : MonoBehaviour
{
   [SerializeField] private float rotateSpeed = 0.5f;
   [SerializeField] private float rotateAxisY;

   private void Update()
   {
      rotateAxisY = rotateSpeed * Time.deltaTime;
      transform.Rotate(0,rotateAxisY,0);
   }
}
