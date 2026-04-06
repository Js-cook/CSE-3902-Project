using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

// NOTE
// This code was based off the audio example in the Monogame documentation
// https://docs.monogame.net/articles/tutorials/building_2d_games/15_audio_controller/index.html

public class AudioController
{
    
    private List<SoundEffectInstance> ActiveSoundEffectInstances;

    public AudioController()
    {
        ActiveSoundEffectInstances = new List<SoundEffectInstance>();
    }

    public SoundEffectInstance PlaySoundEffect(SoundEffect soundEffect, float volume=0.5f, float pitch=1.0f, float pan=0.0f, bool isLooped=false) 
    {
        SoundEffectInstance soundEffectInstance = soundEffect.CreateInstance();

        soundEffectInstance.Volume = volume;
        soundEffectInstance.Pitch = pitch;
        soundEffectInstance.Pan = pan;
        soundEffectInstance.IsLooped = isLooped;

        soundEffectInstance.Play();

        ActiveSoundEffectInstances.Add(soundEffectInstance);

        return soundEffectInstance;
    }

    public void PlaySong(Song song, bool isRepeating = true)
    {
        if(MediaPlayer.State == MediaState.Playing)
        {
            MediaPlayer.Stop();
        }

        MediaPlayer.Volume = 0.35f;
        MediaPlayer.Play(song);
        MediaPlayer.IsRepeating = isRepeating;
    }

    public void StopSong()
    {
        if(MediaPlayer.State == MediaState.Playing)
        {
            MediaPlayer.Stop();
        }
    }

    public void Update()
    {
        for (int i = ActiveSoundEffectInstances.Count - 1; i >= 0; i--)
        {
            SoundEffectInstance inst = ActiveSoundEffectInstances[i];
            if(inst.State == SoundState.Stopped)
            {
                if (!inst.IsDisposed)
                {
                    inst.Dispose();
                }
                ActiveSoundEffectInstances.RemoveAt(i);
            }
        }
    }
}
