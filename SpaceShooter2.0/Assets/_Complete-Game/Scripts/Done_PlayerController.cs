using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public List<Transform> shotSpawn = new List<Transform>();
	public float fireRate;
	 
	private float nextFire;

    public EShipType m_ShipType;
	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
            
            if(m_ShipType == EShipType.Ship1 || m_ShipType == EShipType.Ship3)
            {
                Instantiate(shot, shotSpawn[0].position, shotSpawn[0].rotation);
            }
            else if(m_ShipType == EShipType.Ship2)
            {
                Instantiate(shot, shotSpawn[0].position, shotSpawn[0].rotation);
                Instantiate(shot, shotSpawn[1].position, shotSpawn[1].rotation);
            }			

			GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
