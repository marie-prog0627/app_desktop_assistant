using UnityEngine;
using System.Collections;
 
public class SoundEvent : MonoBehaviour {
 
    public Collider col;
	public AudioSource audioSource;		//　AudioSource
	public AudioClip[] se;				//　効果音の配列
 
	//　挨拶
	void Greeting() {
        Debug.Log("Hello!");
		audioSource.PlayOneShot (se[0]);
	}
}