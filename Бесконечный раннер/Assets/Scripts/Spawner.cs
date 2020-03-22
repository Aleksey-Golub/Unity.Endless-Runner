﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime = 0;     // вермя с последненго спавна

    private void Start()
    {
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                // было // Instantiate(_enemyPrefab, _spawnPoints[spawnPointNumber]);

                // стало
                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.transform.position = spawnPoint;
        enemy.SetActive(true);
    }
}
