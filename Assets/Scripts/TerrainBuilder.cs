using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBuilder : MonoBehaviour {

	public float _padding;

	public GameObject _firstTilePrefab;
	public GameObject _emptyChunkPrefab;
	public List<GameObject> _chunkPrefabs;

	private int _nextPrefabX = 0;
	private int _prefabWidth = 5;

	// Use this for initialization
	void Start () {
		GameObject firstChunk = Instantiate (_firstTilePrefab);
		firstChunk.transform.position = new Vector3 (-1, 0, 0);

		GameObject emptyChunk = Instantiate (_emptyChunkPrefab);
		emptyChunk.transform.position = new Vector3 (_nextPrefabX, 0, 0);
		_nextPrefabX += _prefabWidth;

		for (int i = 0; i < 5; i++) {
			GenerateNextChunk ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_nextPrefabX < transform.position.x + _padding) {
			GenerateNextChunk ();
		}
	}

	private void GenerateNextChunk() {
		GameObject nextChunk = Instantiate (_chunkPrefabs [Random.Range (0, _chunkPrefabs.Count)]);
		nextChunk.transform.position = new Vector3 (_nextPrefabX, 0, 0);
		_nextPrefabX += _prefabWidth;
	}
}
