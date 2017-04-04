using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemiesController : MonoBehaviour
{

	public Transform spawnPoint;
	public GameObject Enemy;

	void Start ()
	{
		Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
        NotificationCenter.DefaultCenter().AddObserver(this, "AnotherEnemy");
	}

    private void AnotherEnemy()
    {
        Invoke("SpawnEnemy", 1f);
    }
    void SpawnEnemy()
    {
        Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
