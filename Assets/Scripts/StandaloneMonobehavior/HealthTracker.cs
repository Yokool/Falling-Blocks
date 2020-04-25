using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    [SerializeField]
    private float health;

    private float startingHealth;

    public bool dead = false;

    public IOnDeath onDeath;

    private Material objectMaterial;

    [SerializeField]
    private Material endMaterial;

    private Color endColor;

    void Start()
    {

        onDeath = gameObject.GetComponent<IOnDeath>();
        objectMaterial = gameObject.GetComponent<Renderer>().material;
        endColor = endMaterial.color;

        startingHealth = health;
        ChangeColor();

        

    }

    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount)
    {

        if (dead)
        {
            return;
        }

        health -= damageAmount;

        ChangeColor();

        if(health <= 0)
        {
            onDeath.OnDeath();
            dead = true;
        }

    }

    public void ChangeColor()
    {

        float percentage = Mathf.Abs(health / startingHealth);

        float r = Mathf.Lerp(endColor.r, objectMaterial.color.r, percentage);
        float g = Mathf.Lerp(endColor.g, objectMaterial.color.g, percentage);
        float b = Mathf.Lerp(endColor.b, objectMaterial.color.b, percentage);

        objectMaterial.color = new Color(r, g, b);

    }
}




