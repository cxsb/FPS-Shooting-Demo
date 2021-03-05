using UnityEngine;
using System.Collections;

namespace A2
{
	public enum CasingType
	{
		Rifle = 1,
		Pistol = 2,
		Shotgun = 3
	}

	public class Casing : MonoBehaviour
	{
		public CasingType casingType;

		[Header("Force X")]
		[Tooltip("Minimum force on X axis")]
		public float minimumXForce;		
		[Tooltip("Maimum force on X axis")]
		public float maximumXForce;
		[Header("Force Y")]
		[Tooltip("Minimum force on Y axis")]
		public float minimumYForce;
		[Tooltip("Maximum force on Y axis")]
		public float maximumYForce;
		[Header("Force Z")]
		[Tooltip("Minimum force on Z axis")]
		public float minimumZForce;
		[Tooltip("Maximum force on Z axis")]
		public float maximumZForce;
		[Header("Rotation Force")]
		[Tooltip("Minimum initial rotation value")]
		public float minimumRotation;
		[Tooltip("Maximum initial rotation value")]
		public float maximumRotation;
		[Header("Despawn Time")]
		[Tooltip("How long after spawning that the casing is destroyed")]
		public float despawnTime;

		[Header("Audio")]
		public AudioClip[] casingSounds;
		public AudioSource audioSource;

		[Header("Spin Settings")]
		//How fast the casing spins
		[Tooltip("How fast the casing spins over time")]
		public float speed = 2500.0f;

		//Launch the casing at start
		public void PopOut(Transform spawnPoint) 
		{
			//Random rotation of the casing
			Vector3 popOutRotation = new Vector3(
				Random.Range(minimumRotation, maximumRotation), //X Axis
				Random.Range(minimumRotation, maximumRotation), //Y Axis
				Random.Range(minimumRotation, maximumRotation));
			GetComponent<Rigidbody>().AddTorque ( spawnPoint.rotation * popOutRotation * Time.deltaTime);

			//Random direction the casing will be ejected in
			Vector3 popOutForce = new Vector3(
				Random.Range (minimumXForce, maximumXForce),  //X Axis
				Random.Range (minimumYForce, maximumYForce),  //Y Axis
				Random.Range (minimumZForce, maximumZForce));
			GetComponent<Rigidbody>().AddForce (spawnPoint.rotation * popOutForce); //Z Axis	

			StartCoroutine (RemoveCasing ());	     
		}

		private void OnTriggerEnter(Collider other)
		{
			audioSource.clip = casingSounds
				[Random.Range(0, casingSounds.Length)];
			//Play the random casing sound
			audioSource.Play();
		}

		private IEnumerator RemoveCasing()
		{
			//Destroy the casing after set amount of seconds
			yield return new WaitForSeconds (despawnTime);
			//Destroy casing object
			if(casingType == CasingType.Rifle) CasingPool.Instance.rifleCasingPool.Store(this.gameObject);
			gameObject.SetActive(false);
		}
	}
}