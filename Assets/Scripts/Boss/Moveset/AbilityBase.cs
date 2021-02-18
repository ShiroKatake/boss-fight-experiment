using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBase : MonoBehaviour
{
	protected bool canUse;

	protected abstract void Ability();

	public void Trigger()
	{
		canUse = true;
	}

	// Update is called once per frame
	void Update()
    {
		if (canUse)
			Ability();
    }
}
