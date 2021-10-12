using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    
    public Slider slider;
    public Gradient gradiant;
    public Image fill;
   // PlayerMovement Player;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradiant.Evaluate(slider.normalizedValue);
    }
    //private void Start()
    //{
    //    Healthbar = GetComponent<Image>();
    //    Player = FindObjectOfType<PlayerMovement>();
    //  //  Healthbar
    //}
    //private void Update()
    //{
    //   // CurrentHealth = Player.health;
    //    Healthbar.fillAmount = CurrentHealth / MaxHealth;
    //}
    //[SerializeField]
    //private int maxH = 100;

    //private int currentH;

    ////jotain mitä en tiedä
    //public event System.Action<float> OnHealthPctChanged = delegate { };

    //private void OnEnable()
    //{
    //    currentH = maxH;
    //}
    //private void ModifyHealth(int amonut)
    //{
    //    currentH += amonut;
    //    float currentHPct = (float)currentH / (float)maxH;
    //    OnHealthPctChanged(currentHPct);
    //}
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //        ModifyHealth(-10);
    //}
}
