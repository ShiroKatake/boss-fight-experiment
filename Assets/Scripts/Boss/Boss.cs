using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EElement
{
	Fire,
	Thunder
}

public class Boss : MonoBehaviour
{
	private EElement element;

	public EElement Element { get => element; }

	// Start is called before the first frame update
    void Start()
    {
		GetComponent<ElementalCharge>().Execute();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
