﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health=50f;

    public void TakeDamage(float amount)
    {
    	health -= amount;
    	if(health <= 0f)
    	{
    		Die();
    	}
    }
    void Die()
    {
    	Destroy(gameObject);
        Score.count -= 1;
    }
}
