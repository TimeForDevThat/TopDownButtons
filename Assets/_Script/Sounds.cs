using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds;
    public SoundsAll[] SoundRandom;

    private AudioSource asr => GetComponent<AudioSource>();

    public void PlaySounds(int i, float volume = 1f, bool random = false, bool destroy = false, float p1 = 0.85f, float p2 = 1.2f) {
        AudioClip clip = random ? SoundRandom[i].soundAll[Random.Range(0, SoundRandom[i].soundAll.Length)] : sounds[i];
        asr.pitch = Random.Range(p1, p2);

        if (destroy)
            AudioSource.PlayClipAtPoint(clip, transform.position, volume);
        else
            asr.PlayOneShot(clip, volume);
    }

    [System.Serializable]
    public class SoundsAll {
        public AudioClip[] soundAll;
    }
}
