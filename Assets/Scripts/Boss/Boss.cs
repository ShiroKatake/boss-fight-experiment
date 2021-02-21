using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Boss element. Used for elemental attacks.
/// </summary>
public enum EElement
{
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

	public EElement Element { get => element; }

	//Initialization Methods-------------------------------------------------------------------------------------------------------------------------

	// Start is called before the first frame update
	void Start()
    {
		GetComponent<ElementalCharge>().Execute();
		//GetComponent<ElementalRelease>().Execute((int)EElement.Fire);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	/// <summary>
	/// Gets a random element for an attack.
	/// </summary>
	private void GetRandomElement()
	{
		element = (EElement)Random.Range(0, 2);
	}
}
