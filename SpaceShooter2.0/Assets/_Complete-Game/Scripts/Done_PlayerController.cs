using UnityEngine;
using System.Collections;

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
    public Transform shotSpawn;
    public float fireRate;
    private float m_MoveDirectionX;
    private float m_MoveDirectionY;
    private float moveHorizontal;
    private int m_PlayerIndex;



    private float nextFire;
    private void Start()
    {
        m_PlayerIndex = 2;
    }

    void Update()
    {
        if (m_PlayerIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GetComponent<AudioSource>().Play();
            }
        }

        if(m_PlayerIndex ==2)
        {
            if (Input.GetKeyDown(KeyCode.RightControl) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GetComponent<AudioSource>().Play();
            }
        }
    }

    void FixedUpdate()
    {
        if (m_PlayerIndex == 1)
        {
            if (Input.GetKey(KeyCode.D))
            {
                m_MoveDirectionX = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                m_MoveDirectionX = -1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                m_MoveDirectionY = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                m_MoveDirectionY = -1;
            }

            //float moveHorizontal= Input.GetAxis ("Horizontal");

            float moveVertical = m_MoveDirectionY * Time.deltaTime * speed;
            float moveHorizontal = m_MoveDirectionX * Time.deltaTime * speed;

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            GetComponent<Rigidbody>().velocity = movement * speed;

            GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );
            m_MoveDirectionX = 0;
            m_MoveDirectionY = 0;
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
        }
        if (m_PlayerIndex == 2)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                m_MoveDirectionX = 1;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                m_MoveDirectionX = -1;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                m_MoveDirectionY = 1;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                m_MoveDirectionY = -1;
            }

            //float moveHorizontal= Input.GetAxis ("Horizontal");

            float moveVertical = m_MoveDirectionY * Time.deltaTime * speed;
            float moveHorizontal = m_MoveDirectionX * Time.deltaTime * speed;

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            GetComponent<Rigidbody>().velocity = movement * speed;

            GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );
            m_MoveDirectionX = 0;
            m_MoveDirectionY = 0;
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
        }
    }
}
