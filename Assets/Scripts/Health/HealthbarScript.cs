using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour {

    [SerializeField]
    private Image m_hbOne;
    public Image HbOne
    {
        get { return m_hbOne; }
        set { m_hbOne = value; }
    }

    [SerializeField]
    private Image m_hbTwo;
    public Image HbTwo
    {
        get { return m_hbTwo; }
        set { m_hbTwo = value; }
    }

    [SerializeField]
    private Image m_hbThree;
    public Image HbThree
    {
        get { return m_hbThree; }
        set { m_hbThree = value; }
    }

    [SerializeField]
    private Image m_hbFour;
    public Image HbFour
    {
        get { return m_hbFour; }
        set { m_hbFour = value; }
    }

    [SerializeField]
    private Image m_hbFive;
    public Image HbFive
    {
        get { return m_hbFive; }
        set { m_hbFive = value; }
    }

    [SerializeField]
    private float m_health;
    public float Health
    {
        get { return m_health; }
        set { m_health = value; }
    }

    [SerializeField]
    private float m_maxHealth;
    public float MaxHealth
    {
        get { return m_maxHealth; }
        set { m_maxHealth = value; }
    }

    [SerializeField]
    private bool m_isPlayerLife;
    public bool IsPlayerLife
    {
        get { return m_isPlayerLife; }
        set { m_isPlayerLife = value; }
    }

    // Update is called once per frame
    void Update () {
        if (IsPlayerLife)
        {
            UpdateHealthbar();
        }
    }

    void UpdateHealthbar()
    {
        float healthValue = Health / MaxHealth;

        if(healthValue > 0.2f)
        {
            HbOne.color = new Color(0.0f, 255.0f, 0.0f);
        }
        else
        {
            HbOne.color = new Color(255.0f, 0.0f, 0.0f);
        }

        if (healthValue > 0.4f)
        {
            HbTwo.color = new Color(0.0f, 255.0f, 0.0f);
        }
        else
        {
            HbTwo.color = new Color(255.0f, 0.0f, 0.0f);
        }

        if (healthValue > 0.6f)
        {
            HbThree.color = new Color(0.0f, 255.0f, 0.0f);
        }
        else
        {
            HbThree.color = new Color(255.0f, 0.0f, 0.0f);
        }

        if (healthValue > 0.8f)
        {
            HbFour.color = new Color(0.0f, 255.0f, 0.0f);
        }
        else
        {
            HbFour.color = new Color(255.0f, 0.0f, 0.0f);
        }

        if (healthValue > 0.95f)
        {
            HbFive.color = new Color(0.0f, 255.0f, 0.0f);
        }
        else
        {
            HbFive.color = new Color(255.0f, 0.0f, 0.0f);
        }
    }

    public void takeDamages(float damages)
    {
        Health = Health - damages;
        if(Health < 0.0f)
        {
            Health = 0.0f;
        }
    }
}
