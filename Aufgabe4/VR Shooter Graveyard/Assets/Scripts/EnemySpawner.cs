using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Das Gegner-Prefab
    public Transform[] spawnPoints; // Die Spawn-Punkte

    public float spawnInterval = 5f; // Intervall zwischen den Spawns
    public float objectLifetime = 4f; // Lebensdauer des erzeugten Objekts

    private float nextSpawnTime = 0f; // Zeit bis zum nächsten Spawn
    private bool spawnEnabled = false; // Variable, um das Spawnen der Gegner zu aktivieren/deaktivieren

    void Update()
    {
        // Überprüfen Sie, ob es Zeit ist für einen neuen Spawn und das Spawnen aktiviert ist
        if (spawnEnabled && Time.time >= nextSpawnTime)
        {
            // zufälligen Spawn-Punkt aus
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Gegner an dem ausgewählten Spawn-Punkt
            GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);

            // Zeit bis zum nächsten Spawn
            nextSpawnTime = Time.time + spawnInterval;

            // Coroutine zum automatischen Löschen des Objekts
            StartCoroutine(DestroyObjectDelayed(enemy, objectLifetime));
        }
    }

    private IEnumerator DestroyObjectDelayed(GameObject obj, float delay)
    {
        // Warten für die definierte Dauer
        yield return new WaitForSeconds(delay);

        // Zerstöre das Objekt nach der Wartezeit
        Destroy(obj);
    }

    // Methode zum Aktivieren des Spawnens der Gegner
    public void StartEnemySpawning()
    {
        spawnEnabled = true;
        nextSpawnTime = Time.time;
    }

    // Methode zum Deaktivieren des Spawnens der Gegner
    public void StopEnemySpawning()
    {
        spawnEnabled = false;
    }
}
