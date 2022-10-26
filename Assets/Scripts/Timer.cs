using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Header("Set time")]
    [SerializeField] private float selectingOptionTime = 4f;

    [Header("Timer Image")]
    [SerializeField] private Image clock;
    private float currentTimer;
    private float fractionTimer;

    
    public bool timeReset;
    
    void Start()
    {
        currentTimer = selectingOptionTime;
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enabled){ 
            UpdateTimer();
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        clock.fillAmount = fractionTimer;
    }
    
    private void UpdateTimer()
    {
        currentTimer -= Time.deltaTime;
        
        if (currentTimer<=0)
        {
            currentTimer = selectingOptionTime; 
            timeReset = true;
        }
        fractionTimer = currentTimer / selectingOptionTime;
        
        
    }

    public void ResetAndStartTimer(){
        enabled = true;
        currentTimer = selectingOptionTime;
        fractionTimer = currentTimer / selectingOptionTime;
    }
}