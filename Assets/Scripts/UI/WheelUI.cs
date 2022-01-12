using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WheelUI : MonoBehaviour
{
    public List<string> Categories;

    public Transform PlayButton;

    public Transform Wheel;

    public float RotateDuration;

    public int AmountRotations;

   public void SpinWheel()
   {
       float randomAngle = Random.Range(0, 360);

       Debug.Log(GetLandedCategory(randomAngle));

       float rotateAngles = (360 * AmountRotations) + randomAngle;

       Wheel.DOLocalRotate(new Vector3(0, 0, rotateAngles * -1), RotateDuration, RotateMode.FastBeyond360).onComplete += WheelFinishedRotating;
   }

   private void WheelFinishedRotating()
   {
       PlayButton.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
   }

   public string GetLandedCategory(float angle)
   {
       var anglePerCategory = 360 / Categories.Count; //45
       return Categories[(int) (angle / anglePerCategory)];

   }
}
