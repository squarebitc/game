using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFieldManager : MonoBehaviour
{
	[SerializeField]
	private GameObject tilePrefab;

	[SerializeField]
	private Vector3 startPosition;

	[SerializeField]
	private float tileSpace;

	private List<GameObject> generatedTiles = new List<GameObject>();

	// Start is called before the first frame update
	void Start()
	{
		generatePlayTiles(3, 3);
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void generatePlayTiles(int xCount, int zCount)
	{
		float x = startPosition.x;

		for (int ix = 0; ix < xCount; ix++)
		{
			float z = startPosition.z;
			GameObject xTile = Instantiate(tilePrefab);
			xTile.transform.SetParent(this.transform);
			xTile.transform.position = new Vector3(x, 0, z);
			generatedTiles.Add(xTile);
			for (int iz = 1; iz < zCount; iz++)
			{
				z -= tileSpace;
				GameObject yTile = Instantiate(tilePrefab);
				yTile.transform.SetParent(this.transform);
				yTile.transform.position = new Vector3(x, 0, z);
				generatedTiles.Add(yTile);
			}
			x += tileSpace;
		}
	}
}
