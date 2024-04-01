using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IgracHP : MonoBehaviour
{
    public float HP;
    private float maxHP = 100f;


    [Header("Health")]
    public Image frontHealthBar;
    public Image backHealthBar;
    public float chipSpeed = 2f;

    [Header("DMG Overlay")]
    public Image overlay;
    public Image overlay2;
    public float duzinaEfekta;
    public float trajanjeEfekta;
    private float vremeEfekta;
    private float vremeEfekta2;

    void Start()
    {
        HP = maxHP;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
        overlay2.color = new Color(overlay2.color.r, overlay2.color.g, overlay2.color.b, 0);
    }

    void Update()
    {
        HP = Mathf.Clamp(HP, 0, maxHP);
        UpdateHpUI();

        if (overlay.color.a > 0)
        {
            vremeEfekta += Time.deltaTime;
            if(vremeEfekta > trajanjeEfekta)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * vremeEfekta;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }

        if (overlay2.color.a > 0)
        {
            vremeEfekta2 += Time.deltaTime;
            if(vremeEfekta2 > trajanjeEfekta)
            {
                float tempAlpha = overlay2.color.a;
                tempAlpha -= Time.deltaTime * vremeEfekta2;
                overlay2.color = new Color(overlay2.color.r, overlay2.color.g, overlay2.color.b, tempAlpha);
            }
        }

        if(HP <= 0)
            {
                SceneManager.LoadScene("Smrt");
            }
    }

    public void UpdateHpUI()
    {
        float puniPrednji = frontHealthBar.fillAmount;
        float puniZadnji = backHealthBar.fillAmount;
        float hFraction = HP / maxHP;

        if (puniPrednji >= hFraction)
        {
            backHealthBar.fillAmount = hFraction;
        }
        Debug.Log(HP);
    }

    public void PrimljenDMG(float dmg)
    {
        HP -= dmg;
        trajanjeEfekta = 0;
        vremeEfekta = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
    }
    
    public void PrimljenHP(float heal)
    {
        HP += heal;
        trajanjeEfekta = 0;
        vremeEfekta2 = 0;
        overlay2.color = new Color(overlay2.color.r, overlay2.color.g, overlay2.color.b, 1);
    }
}
