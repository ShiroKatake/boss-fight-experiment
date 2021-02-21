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

//TODO: Create a queue to enqueue and dequeue abilities
//CSV structure: [Time to execute] [Ability name]

/// <summary>
/// Blueprint for boss.
/// </summary>
public class Boss : MonoBehaviour
{
	//Private Fields---------------------------------------------------------------------------------------------------------------------------------

	//Serialized Fields----------------------------------------------------------------------------
	private Queue<Ability> abilityTimeline;
	private Ability lastAbility;
	private Ability currentAbility;

	private EElement element;
	private ElementalCharge elementalCharge;
	private ElementalRelease elementalRelease;

	//Basic Public Properties----------------------------------------------------------------------

	public EElement Element { get => element; }

	//Initialization Methods-------------------------------------------------------------------------------------------------------------------------

	private void Awake()
	{
		elementalCharge = GetComponent<ElementalCharge>();
		elementalRelease = GetComponent<ElementalRelease>();
	}

	// Start is called before the first frame update
	void Start()
    {
		elementalCharge.Execute();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	IEnumerator BossTimeline()
	{
		GetComponent<ElementalCharge>().Execute();
		yield return null;
	}

	/// <summary>
	/// Gets a random element for an attack.
	/// </summary>
	private void GetRandomElement()
	{
		element = (EElement)Random.Range(0, 2);
	}
}
