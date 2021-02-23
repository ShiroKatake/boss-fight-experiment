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

//TODO: Create a queue to enqueue and dequeue abilities
//CSV structure: [Time to execute] [Ability name]

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

	//Initialization Methods-------------------------------------------------------------------------------------------------------------------------

	private void Awake()
	{

	}

	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
