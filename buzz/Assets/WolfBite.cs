using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WolfBite : MonoBehaviour
{
    public AudioClip BiteSound;
    private AudioSource Source;

    public void Awake()
    {
        Source = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        this.GetComponent<SphereCollider>().enabled = false;
        Source.PlayOneShot(BiteSound);

        StartCoroutine(BiteHappens());
    }

    public IEnumerator BiteHappens()
    {
        yield return new WaitForSeconds(1);
        this.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
