using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool inizialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static bool Inizialized { get { return inizialized; } }
    public static void Initialize(AudioSource source)
    {
        inizialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.BlockDestroy, 
            Resources.Load<AudioClip>("BlockDestroyd"));
        audioClips.Add(AudioClipName.MainMenuTheam,
            Resources.Load<AudioClip>("MainMusic"));
        audioClips.Add(AudioClipName.PaddleHit,
            Resources.Load<AudioClip>("Bounce"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
