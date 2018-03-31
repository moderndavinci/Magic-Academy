using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusic : ManagerScene<SceneMusic>
{

    public  string pick = "Pick";
    public string foot = "Foot";
    public  string button = "Button";
    public  string attack01 = "Attack01";
    public  string attack021 = "Attack021";
    public  string attack022 = "Attack022";
    public  string attack03 = "Attack03";
    public  string attack04 = "Attack04";
    public Dictionary<string, AudioClip> musics = new Dictionary<string, AudioClip>();
    // Use this for initialization
    void Start()
    {
        AudioClip[] Temps = Resources.LoadAll<AudioClip>("Music/SkillMusic");
        for (int i = 0; i < Temps.Length; i++)
        {
            musics.Add(Temps[i].name, Temps[i]);
        }
    }
    //播放音效
    public void PlayAudio(string _name,Vector3 _position)
    {
        AudioSource.PlayClipAtPoint(SceneMusic.Instance.musics[_name], _position);
    }
    ////暂停音效
    //public void PuseAudio()
    //{
    //    AudioSource.
    //}
}
