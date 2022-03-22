using UnityEngine;
//https://www.youtube.com/watch?v=-f--hnAHGQI

public class Breakable : MonoBehaviour
{
	[SerializeField] GameObject brokenObject;
	[SerializeField] float breakForce = 1f;
	[SerializeField] float collisionMultiplier = 100f;

	bool broken = false;

	void OnCollisionEnter(Collision collision)
	{
		if (!broken)
		{
			if(collision.relativeVelocity.magnitude >= breakForce)
			{
				broken = true;
				var replacement = Instantiate(brokenObject, transform.position, transform.rotation);
				var rbs = replacement.GetComponentsInChildren<Rigidbody>();
				foreach (var rb in rbs)
				{
					rb.AddExplosionForce(collision.relativeVelocity.magnitude * collisionMultiplier, collision.contacts[0].point, 2);
				}

				Destroy(gameObject);
			}
		}
	}

}
