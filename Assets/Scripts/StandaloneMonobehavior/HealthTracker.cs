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

    void Start()
    {

        onDeath = gameObject.GetComponent<IOnDeath>();
        objectMaterial = gameObject.GetComponent<Renderer>().material;
        ChangeColor();

        startingHealth = health;

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

        float rgb = Mathf.Lerp(0, 1, percentage);

        objectMaterial.color = new Color(rgb, rgb, rgb);

    }
}




