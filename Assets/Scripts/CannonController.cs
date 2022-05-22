using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject barrel;
    public GameObject shotSpawn;
    public GameObject shot;

    public float rateOfFire = 2f;
    public float shotSpeed = 800f;
    
    float fireDelay;

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(0f, rotation, 0f);

        float pitch = Input.GetAxis("Vertical") + barrel.transform.rotation.eulerAngles.x;
        pitch = Mathf.Clamp(pitch, 320f, 359f);
        Quaternion barrelRotation = Quaternion.Euler(pitch, 0f, 0f);
        barrel.transform.localRotation = barrelRotation;

        if (Input.GetButton("Fire3") && Time.time > fireDelay)
		{
            fireDelay = Time.time + rateOfFire;
            GameObject shotInstance = Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            shotInstance.GetComponent<Rigidbody>().AddForce(shotSpawn.transform.forward * shotSpeed);
		}
    }
}
