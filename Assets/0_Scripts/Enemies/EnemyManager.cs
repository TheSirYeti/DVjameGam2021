using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public static EnemyManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else Destroy(gameObject);
    }

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }
    
    public List<Enemy> GetEnemies()
    {
        return enemies;
    }
}
