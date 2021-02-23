using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Boss element. Used for elemental attacks.
/// </summary>
public enum EElement
{
	None,
	Fire,
	Thunder
}

/// <summary>
/// Blueprint for boss.
/// </summary>
public class Boss : MonoBehaviour
{
	//Private Fields---------------------------------------------------------------------------------------------------------------------------------

	//Serialized Fields----------------------------------------------------------------------------

	private EElement element;

	//Basic Public Properties----------------------------------------------------------------------

	public EElement Element { get => element; set => element = value; }
}
