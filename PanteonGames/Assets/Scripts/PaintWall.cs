using System;
using DG.Tweening;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PaintWall : MonoBehaviour
{
   [SerializeField] private SwerveInputSystem swerveInputSystem;
   [SerializeField] private TextMeshProUGUI percentageText;
   [SerializeField] private TextMeshProUGUI recordText;
   [SerializeField] private Image image;

   
   [SerializeField] private  float swerveSpeed=0.5f;
   public float swerveAmount;
    
 

    
    private void Update()
    {
        if ( swerveInputSystem.MoveFactorX!=0)
        {
            swerveAmount = Mathf.Abs(swerveInputSystem.MoveFactorX) * Time.deltaTime * swerveSpeed;
            
           image.fillAmount += swerveAmount;
           percentageText.text = "% " + Math.Round(image.fillAmount*100,1);
           
        }
        
    }

    private void OnEnable()
    {
        DOTween.Init();
        transform.DOMoveY(5, 2f);
    }

    private void OnDisable()
    {
        UIManager.instance.ActiveRestartButton();
        recordText.text = "Your record is " + Math.Round(image.fillAmount*100);
    }
}
