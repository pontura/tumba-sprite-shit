using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

    public class AudioManager : MonoBehaviour
    {
        static AudioManager mInstance = null;

        public AudioSourceManager[] all;
        [Serializable]
        public class AudioSourceManager
        {
            public string sourceName;
            public AudioSource audioSource;
            public float volume = 1;
        }
        public AudioSource[] clips;

        public static AudioManager Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = FindObjectOfType<AudioManager>();

                    if (mInstance == null)
                    {
                        GameObject go = Instantiate(Resources.Load<GameObject>("AudioManager")) as GameObject;
                        mInstance = go.GetComponent<AudioManager>();
                    }
                }
                return mInstance;
            }
        }
        void Awake()
        {
            if (!mInstance)
                mInstance = this;
            else
            {
                Destroy(this.gameObject);
                return;
            }

            DontDestroyOnLoad(this);
        }
        void Start()
        {
            foreach (AudioSourceManager m in all)
            {
                if (m.audioSource == null)
                    m.audioSource = gameObject.AddComponent<AudioSource>();
                m.audioSource.volume = m.volume;
            }
        }
        public void StopSound(string sourceName)
        {
            AudioSource audioSource = GetAudioSource(sourceName); if (audioSource == null) return;
            audioSource.Stop();
        }
        public void PlaySound(string audioName, string sourceName = "music", bool loop = false, bool noRepeat = false)
        {
            AudioClip clip = Resources.Load<AudioClip>("Audio/" + audioName) as AudioClip;
            PlaySound(clip, sourceName, loop);
        }
        public void PlaySound(AudioClip audioClip, string sourceName = "common", bool loop = false, bool noRepeat = false)
        {
            AudioSource audioSource = GetAudioSource(sourceName); if (audioSource == null) return;
            if (noRepeat)
            {
                if (audioSource.clip == audioClip && audioSource.isPlaying)
                    return;
            }
            audioSource.clip = audioClip;
            audioSource.loop = loop;
            audioSource.Play();
        }

        public void PlaySoundOneShot(string sourceName, string audioName, bool noRepeat = false)
        {
            AudioSource audioSource = GetAudioSource(sourceName);
            AudioClip clip = Resources.Load<AudioClip>("Audio/" + audioName) as AudioClip;

            //AudioClip clip = AssetsBundleManager.Instance.assetsBundleLoader.GetAssetAsAudioClip("audio", audioName);
            if (noRepeat)
            {
                if (audioSource.clip == clip && audioSource.isPlaying)
                    return;
            }
            audioSource.PlayOneShot(clip);
        }
        AudioSource GetAudioSource(string sourceName)
        {
            foreach (AudioSourceManager m in all)
            {
                if (m.sourceName == sourceName)
                    return m.audioSource;
            }
            return null;
        }

    }