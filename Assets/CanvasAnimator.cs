using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAnimator : MonoBehaviour
{
    public static CanvasAnimator instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public Animator sliderPlayStageAnimator;

}
