using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

    [SerializeField]
    private Transform m_projectilePrefab;
    public Transform ProjectilePrefab
    {
        get { return m_projectilePrefab; }
        set { m_projectilePrefab = value; }
    }

    private bool canShoot;

    private List<GameObject> projectiles;

	// Use this for initialization
	void Start () {
        canShoot = true;
        projectiles = new List<GameObject>();
        InvokeRepeating("DestroyLastBullet", 0.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(1) && canShoot)
        {
            canShoot = false;
            Invoke("CanShootAgain", 1.0f);
            GameObject projectile = Instantiate(ProjectilePrefab, transform.position + transform.forward * 2.0f, Quaternion.identity).gameObject;
            Rigidbody Body = projectile.GetComponent<Rigidbody>();
            Body.AddForce(transform.forward * 15.0f, ForceMode.Impulse);
            projectiles.Add(projectile);
        }
	}

    void DestroyLastBullet()
    {
        if(projectiles.Count > 0)
        {
            GameObject lastProj = projectiles[projectiles.Count - 1];
            projectiles.Remove(lastProj);
            Destroy(lastProj);
        }
    }

    void CanShootAgain()
    {
        canShoot = true;
    }
}
