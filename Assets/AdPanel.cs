using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AdPanel : MonoBehaviour
{
	private bool hidden;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(Fade());
	}

	IEnumerator Fade()
	{
		while (!hidden)
		{
			yield return new WaitForSeconds(5f);

			gameObject.SetActive(false);
			hidden = true;
		}
	}
}
