using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
	#region Fields
	[SerializeField]
	private Vector3 startPosition;
	[SerializeField]
	private bool dragged = false;
	#endregion

	#region Methods
	// Start is called before the first frame update
	void Start()
	{
		startPosition = transform.position;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void DragCard(Transform parent)
	{
		dragged = true;
		this.transform.SetParent(parent);
	}

	public void ReleaseCard()
	{
		if (dragged)
		{
			this.transform.SetParent(null);
			playTileCheck();
			dragged = false;
		}
	}

	private void playTileCheck()
	{
		Vector3 origin = transform.position;
		Vector3 direction = Vector3.down * 10;
		if (Physics.Raycast(origin, direction, out RaycastHit hit))
		{
			if (hit.transform.tag.ToUpper() == Constants.Tags.PLAYTILE)
				this.transform.position = hit.transform.position;
		}
		else
		{
			this.transform.position = startPosition;
		}
	}
	#endregion
}
