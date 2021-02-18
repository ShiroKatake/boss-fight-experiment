using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBase : MonoBehaviour
{
	protected bool isUsing;

	protected abstract void Ability();

	public void Trigger()
	{
		isUsing = true;
	}

	// Update is called once per frame
	void Update()
    {
		if (isUsing)
			Ability();
    }
}
