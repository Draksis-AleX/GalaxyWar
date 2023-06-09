using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDBar : MonoBehaviour
{
    [SerializeField] Slider cdSlider;
    float currentVelocity = 0;
    float cd;
    [SerializeField] float smoothSpeed = 10f;

    private void Start()
    {
        cd = 1;
    }

    public void setCd(float value) {
        cd = value;
    }

    private void Update()
    {
        animationBar();
    }

    public void animationBar() {

        float targetHealth = cd;
        float startHealth = cdSlider.value;

        cdSlider.value = Mathf.SmoothDamp(startHealth, targetHealth, ref currentVelocity, smoothSpeed * Time.deltaTime);
    }
}

