using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public TimerScript timer;
    public ScoreManager scoreManager;
    public Collider gameCollider;
    public float disableDuration = 125f; // 2 Minuten in Sekunden
    public EnemySpawner enemySpawner; // Verknüpfung zum EnemySpawner-Skript
    public AudioSource countdownVoice;

    private void OnCollisionEnter(Collision collision)
    {
        // Überprüfe, ob das Kollisionsobjekt das Tag "bullet" hat
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("RUFT AUF");

            // Score zurück setzen
            scoreManager.ResetScore();
            timer.ResetTimer();
            Debug.Log("AKTUELLER SCORE: " + scoreManager.score);
            // Timer restet

            // startGame.StartSpawning();
            Invoke("StartTimerDelayed", 5f);
            countdownVoice.Play();

            // Collider für die definierte Zeit deaktivieren
            StartCoroutine(DisableColliderForDuration());

            // Gegner spawnen
            enemySpawner.StartEnemySpawning();

            Invoke("StopEnemySpawningDelayed", 130f); // 120 Sekunden = 2 Minuten
        }
    }

    private void StartTimerDelayed()
    {
        timer.StartTimer();
    }

    private IEnumerator DisableColliderForDuration()
    {
        // Collider deaktivieren
        gameCollider.enabled = false;

        // Warte für die definierte Dauer
        yield return new WaitForSeconds(disableDuration);

        // Collider wieder aktivieren
        gameCollider.enabled = true;
    }

    private void StopEnemySpawningDelayed()
    {
        enemySpawner.StopEnemySpawning();
    }
}
