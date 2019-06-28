using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawningCubes : MonoBehaviour {

    public GameObject CubePrefab;
    public int numberOfObjects = 0;
	public int gridSize = 0;
	public float radius = 10f;

	public Button spawnInCircleButton, spawnInGridButton;
	
    private GameObject cubes;

	void Start() {
	
		spawnInCircleButton.onClick.AddListener (StartSpawnInCircle);
		spawnInGridButton.onClick.AddListener (StartSpawnInGrid);
		spawnInGridButton.gameObject.SetActive (false);
	}


	void StartSpawnInCircle()
	{
		StartCoroutine (SpawnInCircle());
		spawnInGridButton.gameObject.SetActive (true);
	}

	IEnumerator SpawnInCircle()
	{
		yield return new WaitForSeconds(1);
		for (int i = 0; i < numberOfObjects; i++) {
			float angle = i * Mathf.PI * 2 / numberOfObjects;
			Vector3 pos = new Vector3 (Mathf.Cos (angle), 0, Mathf.Sin (angle)) * radius;
			cubes = Instantiate (CubePrefab, pos, Quaternion.identity) as GameObject;
			cubes.transform.SetParent (transform);
		}
	}

	void StartSpawnInGrid()
	{
		StartCoroutine (SpawnInGrid());
	}

	IEnumerator SpawnInGrid()
	{
		yield return new WaitForSeconds (2);
		Vector3[] vertices = new Vector3[(gridSize+1) * (gridSize+1)];

		float y = 0;

		for (int i = 0; i <= transform.childCount - 1; ) {

			for ( int z = 0; z <= gridSize-1; z++) {
				for (int x = 0; x <= gridSize-1; x++, i++) {
					vertices[i] = new Vector3(x*radius, y, z*radius);
                    transform.GetChild (i).transform.position = new Vector3 (vertices[i].x+radius/2, y, vertices[i].z);
				}
			}

				
		}



	}
}
