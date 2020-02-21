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
	[SerializeField]
	private GameObject cardGlow;
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

	public void HoverCard()
	{
		this.cardGlow.SetActive(true);
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
		this.cardGlow.SetActive(false);
	}

	private void playTileCheck()
	{
		Vector3 origin = transform.position;
		Vector3 direction = Vector3.down * 10;
		if (Physics.Raycast(origin, direction, out RaycastHit hit))
		{
			if (hit.transform.tag.ToUpper() == Constants.Tags.PLAYTILE)
			{
				Vector3 newPosition = hit.transform.position;
				newPosition.y = this.transform.position.y;
				this.transform.position = newPosition;
			}
		}
		else
		{
			this.transform.position = startPosition;
		}
	}
	#endregion
}
