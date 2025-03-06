
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private int PlayerLives;
    private Vector3 ScreenBounds;
    private bool PlayerIsActive;

    void Start()
    {
        PlayerLives = 1;
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, this.transform.position.z));
        PlayerIsActive = true;
    }

    void Update()
    {
        if (!this.PlayerIsActive)
            AttemptToRespawnPlayer();
    }
    private void AttemptToRespawnPlayer()
    {
        List<Vector3> asteroidLocations = ScanScreenForAsteroids();
        Vector3 potentialSpawn = GenerateRandomLocation();

        foreach (Vector3 location in asteroidLocations)
        {
            Vector3 difference = potentialSpawn - location;
            if (!(Math.Abs(difference.x) >= 2 && Math.Abs(difference.y) >= 2))
                return;
        }

        EnablePlayer(true);
        this.transform.position = potentialSpawn;

        DecreasePlayerLife();
    }
    private List<Vector3> ScanScreenForAsteroids()
    {
        List<Vector3> asteroidLocations = new List<Vector3>();

        GameObject[] allAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject asteroid in allAsteroids)
            if (asteroid.transform.parent == null)
                asteroidLocations.Add(asteroid.transform.position);
        
        return asteroidLocations;
    }
    private Vector3 GenerateRandomLocation()
    {
        float x = UnityEngine.Random.Range(-ScreenBounds.x, ScreenBounds.x);
        float y = UnityEngine.Random.Range(-ScreenBounds.y, ScreenBounds.y);
        return new Vector3(x, y, 0);
    }
    private void DecreasePlayerLife()
    {
        if (--PlayerLives < 0)
            EndGame();
    }
    private void EndGame()
    {
        print("Player is out of Lives");
    }


    public void EnablePlayer(bool isActive)
    {
        if (isActive == false)
        {
            this.transform.position = new Vector3(999,999,999);
            Invoke(nameof(DisablePlayer), 2f);
        }
        else
            this.PlayerIsActive = true;

    }
    private void DisablePlayer()
    {
        this.PlayerIsActive = false;
    }
}

