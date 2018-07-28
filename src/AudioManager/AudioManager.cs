using UnityEngine.Audio;
using System;
using UnityEngine;
using SubjectNerd.Utilities;

namespace UCU {
	public class AudioManager : MonoBehaviour {
		public AudioMixerGroup mixerGroup;

		[Reorderable]
		public Sound[] sounds;

		private void Awake() {
			GameObject audioEmpty = Instantiate(new GameObject("AudioEmpty"), transform.position, Quaternion.identity, transform);

			foreach (Sound s in sounds) {
				s.source = audioEmpty.AddComponent<AudioSource>();
				s.source.clip = s.clip;
				s.source.loop = s.loop;
				s.source.spatialBlend = s.spatialBlend;

				s.source.outputAudioMixerGroup = mixerGroup;
			}
		}

		private Sound soundByName(string name) {
			return Array.Find(sounds, item => item.name == name);
		}

		public void Play(string sound) {
			Sound s = soundByName(sound);
			if (s == null) {
				Debug.LogWarning("Sound: " + name + " not found!");
				return;
			}

			s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
			s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

			s.source.Play();
		}

		public void Stop(string sound) {
			Sound s = soundByName(sound);
			s.source.Stop();
		}
	}
}
