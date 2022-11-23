﻿//----------------------------------------------------------------------------------
//
// CSOUNDBANK : Stockage des sons
//
//----------------------------------------------------------------------------------

using System;
using System.IO;
using FusionX.Application;
using FusionX.Services;
using Ionic.Zlib;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace FusionX.Banks
{
    public class CSound
    {
		public int handle;
		public SoundEffect sound=null;
        public SoundEffectInstance soundInstance = null;
		public int useCount=0;
		public bool bUninterruptible=false;
		public int nLoops=0;
		public int numSound=0;
		public string name;
        public int type;
        public Song song;
        public bool bSongPlaying;
        public bool bPaused;
        public long timer;
        public int frequency;
        public CRunApp application;

        public CSound(CRunApp app)
        {
            application = app;
        }

        public void loadHandle()
        {
            load();
        }

        public static CSound createFromSound(CSound source)
        {
            CSound snd = new CSound(source.application);
            snd.handle = source.handle;
            snd.sound = source.sound;
            snd.name = source.name;
            snd.type = source.type;
            snd.song = source.song;
            return snd;
        }
        public void load()
        {
            handle = application.file.readAInt()-1;
            var checksum = application.file.readAInt();
            var references = application.file.readAInt();
            var decompressedSize = application.file.readAInt();
            var flags = application.file.readAInt();
            var res = application.file.readAInt();
            var nameLen = application.file.readAInt();
            var size = application.file.readAInt();
            var decompressedData = new CFile(ZlibStream.UncompressBuffer(application.file.readArray(size)));
            File.WriteAllBytes($"snd{handle}",decompressedData.data);
            decompressedData.bUnicode = application.file.bUnicode;
            name = decompressedData.readAString(nameLen);
            var actualSoundData = decompressedData.readArray(decompressedData.data.Length - decompressedData.pointer);
            sound = SoundEffect.FromStream(new MemoryStream(actualSoundData));
            File.WriteAllBytes(name,actualSoundData);

        }

		public void play(int nl, bool bPrio, float v, float p)
		{
            Console.WriteLine("playing "+name);
			nLoops=nl;
			if (nLoops==0)
			{
				nLoops=10000000;
			}

            if (type == 0)
            {
                if (soundInstance != null)
                {
                    soundInstance.Stop();
                    soundInstance.Dispose();
                    soundInstance = null;
                }

                if (soundInstance == null)
                {
                    soundInstance = sound.CreateInstance();
                }
                if (soundInstance != null)
                {
                    soundInstance.Volume = (float)(v / 100.0);
                    soundInstance.Pan = (float)(p / 100.0);
                    soundInstance.Play();
                    bUninterruptible = bPrio;
                }
            }
            else
            {
                if (MediaPlayer.GameHasControl)
                {
                    MediaPlayer.Stop();
                    MediaPlayer.Play(song);
                    bSongPlaying = true;
                    bPaused = false;
                    timer = application.timer+getDuration();
                }
            }
		}

        public void stop()
        {
            if (type == 0)
            {
                if (soundInstance != null)
                {
                    soundInstance.Stop();
                    soundInstance.Dispose();
                    soundInstance = null;
                    bUninterruptible = false;
                }
            }
            else
            {
                if (MediaPlayer.GameHasControl)
                {
                    MediaPlayer.Stop();
                    bSongPlaying = false;
                    bUninterruptible = false;
                }
            }
        }
        public void setVolume(int v)
        {
            if (type == 0)
            {
                if (soundInstance != null)
                {
                    soundInstance.Volume = (float)(v / 100.0);
                }
            }
            else
            {
                if (MediaPlayer.GameHasControl)
                {
                    MediaPlayer.Volume = (float)(v / 100.0);
                }
            }
        }
        public void setPan(int p)
        {
            if (type == 0)
            {
                if (soundInstance != null)
                {
                    soundInstance.Pan = (float)(p / 100.0);
                }
            }
        }
        public void setFrequency(int newFrequency)
        {
            double pitch = ((double)newFrequency)/((double)frequency);
            if (pitch >= 1.0)
                pitch -= 1.0;
            else 
                pitch = ((pitch * 2) - 2);
            pitch = Math.Max(Math.Min(pitch, 1.0), -1.0);
            if (soundInstance != null)
                soundInstance.Pitch = (float)pitch;
        }
        public int getFrequency()
        {
            return frequency;
        }
        public void pause()
        {
            if (type == 0)
            {
                if (soundInstance != null)
                {
                    soundInstance.Pause();
                }
            }
            else
            {
                if (MediaPlayer.GameHasControl)
                {
                    MediaPlayer.Pause();
                    bPaused = true;
                }
            }
        }
        public void resume()
        {
            if (type == 0)
            {
                if (soundInstance != null)
                {
                    soundInstance.Resume();
                }
            }
            else
            {
                if (MediaPlayer.GameHasControl)
                {
                    MediaPlayer.Resume();
                    bPaused = false;
                }
            }
        }
        public bool isPaused()
        {
            if (type == 0)
            {
                if (soundInstance != null)
                {
                    if (soundInstance.State == SoundState.Paused)
                    {
                        return true;
                    }
                }
            }
            else
            {
                return bPaused;
            }
            return false;
        }
        public bool isPlaying()
        {
            if (type == 0)
            {
                if (soundInstance != null)
                {
                    if (soundInstance.State == SoundState.Playing)
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (MediaPlayer.GameHasControl)
                {
                    if (MediaPlayer.State == MediaState.Playing)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public int getDuration()
        {
            TimeSpan time;
            if (type == 0)
            {
                time = sound.Duration;
            }
            else
            {
                time = song.Duration;
            }
            return (int)time.Hours*60*60*1000+time.Minutes*60*1000+time.Seconds*1000+time.Milliseconds;
        }
        public bool checkSound()
        {
            if (type == 0)
            {
                if (soundInstance != null)
                {
                    if (soundInstance.State == SoundState.Stopped)
                    {
                        if (nLoops > 0)
                        {
                            nLoops--;
                            if (nLoops > 0)
                            {
                                soundInstance.Play();
                                return false;
                            }
                        }
                        bUninterruptible = false;
                        soundInstance.Dispose();
                        soundInstance = null;
                        return true;
                    }
                }
            }
            else
            {
                if (bSongPlaying)
                {
                    if (application.timer >= timer)
                    {
                        if (MediaPlayer.State != MediaState.Playing && bPaused == false)
                        {
                            if (nLoops > 0)
                            {
                                nLoops--;
                                if (nLoops > 0)
                                {
                                    MediaPlayer.Play(song);
                                    timer = application.timer + getDuration();
                                    return false;
                                }
                            }
                            bUninterruptible = false;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
