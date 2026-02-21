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


    public SoundEffectInstance PlaySoundEffect(SoundEffect soundEffect, float volume, float pitch, float pan, bool isLooped) 
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

        MediaPlayer.Play(song);
        MediaPlayer.IsRepeating = isRepeating;
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
