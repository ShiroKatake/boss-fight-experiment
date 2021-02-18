using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coil : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private float rotateSpeed;
	[SerializeField] private float pitch;

    // Start is called before the first frame update
    void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
		Orbit();   
    }

	void Orbit()
	{
		transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		transform.Translate(Vector3.up * pitch * Time.deltaTime);
	}
}
