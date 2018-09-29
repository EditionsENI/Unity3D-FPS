using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonControlScript : MonoBehaviour {

    [SerializeField]
    private float m_linearVelocity = 15.0f;
    public float LinearVelocity
    {
        get { return m_linearVelocity; }
        set { m_linearVelocity = value; }
    }

    [SerializeField]
    private float m_angularVelocity = 50.0f;
    public float AngularVelocity
    {
        get { return m_angularVelocity; }
        set { m_angularVelocity = value; }
    }

    [SerializeField]
    private Rigidbody m_body;
    public Rigidbody Body
    {
        get { return m_body; }
        set { m_body = value; }
    }

    [SerializeField]
    private HealthbarScript m_hbScript;
    public HealthbarScript HbScript
    {
        get { return m_hbScript; }
        set { m_hbScript = value; }
    }

    private bool canJump;

    private void Start()
    {
        canJump = true;
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.forward * LinearVelocity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * LinearVelocity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -AngularVelocity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, AngularVelocity * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Space) && canJump)
        {
            canJump = false;
            Invoke("ReuseJump", 2.0f);
            Body.AddForce(Vector3.up * 10.0f, ForceMode.Impulse);
        }

        if(HbScript.Health <= 0.0f)
        {
            SceneManager.LoadScene(0);
        }
    }

    void ReuseJump()
    {
        canJump = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Projectile"))
        {
            HbScript.takeDamages(5.0f + Random.Range(0.0f, 5.0f));
        }
    }
}
