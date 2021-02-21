using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for every boss ability.
/// </summary>
public abstract class AbilityBase : MonoBehaviour
{
	//Protected Fields---------------------------------------------------------------------------------------------------------------------------------

	//Serialized Fields----------------------------------------------------------------------------

	[SerializeField] protected float abilityDuration;

	//Non-Serialized Fields------------------------------------------------------------------------

	protected bool isUsing;
	protected float timePassed;

	/// <summary>
	/// Executes boss ability.
	/// </summary>
	/// <param name="element">Passes boss' element if required.</param>
	public virtual void Execute(int element = 0)
	{
		isUsing = true;
		timePassed = 0f;
	}
}
