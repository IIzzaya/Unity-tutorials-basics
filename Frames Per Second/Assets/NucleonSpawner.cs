using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleonSpawner : MonoBehaviour {

	public float timeGap;
	public float spawnDistance;

	public Nucleon[] nucleonPrefabs;

	void SpawnNucleon(int index)
	{
		Nucleon spawn = Instantiate(nucleonPrefabs[index]);
		spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
	}
	float timeSinceLastSpawn;
	void FixedUpdate()
	{
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn >= timeGap)
		{
			timeSinceLastSpawn -= timeGap;
			SpawnNucleon(Random.Range(0, nucleonPrefabs.Length));
		}

	}
}
