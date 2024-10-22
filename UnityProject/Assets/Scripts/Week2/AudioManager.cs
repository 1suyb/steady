using UnityEngine;
public class AudioManager : Singleton<AudioManager>
{
	private AudioSource _audioSource;
	private string[] _tempAudioList;
	public override void Awake()
	{
		_audioSource = this.gameObject.GetComponentInChildren<AudioSource>();
		if(_audioSource == null)
		{
			_audioSource = this.gameObject.AddComponent<AudioSource>();
		}
	}
	public void StartBGM()
	{
		_audioSource.clip = Resources.Load<AudioClip>("Sound/BGM_01");
		_audioSource.Play();
	}
}