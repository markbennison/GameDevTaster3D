using UnityEngine;
//https://www.youtube.com/watch?v=-f--hnAHGQI

public class Breakable : MonoBehaviour
{
	[SerializeField] GameObject brokenObject;
	[SerializeField] float breakForce = 1f;
	[SerializeField] float collisionMultiplier = 30f;

	bool broken = false;

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Collision Detected.");
		if (!broken)
		{
			Debug.Log("Not Broken.");
			if (collision.relativeVelocity.magnitude >= breakForce)
			{
				Debug.Log("BREAKING!");
				broken = true;

				GameObject replacement = Instantiate(brokenObject, transform.position, transform.rotation);
				Rigidbody[] rigidbodies = replacement.GetComponentsInChildren<Rigidbody>();

				foreach (Rigidbody rigidbody in rigidbodies)
				{
					rigidbody.AddExplosionForce(collision.relativeVelocity.magnitude * collisionMultiplier, 
												collision.contacts[0].point, 
												2);
				}

				Destroy(gameObject);
			}
		}
	}
}