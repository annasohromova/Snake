using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NAudio;
using NAudio.WaveFormRenderer;
using System.Threading;
using uss12;
using NAudio.Wave;

namespace uss12
{
    public class Heli
    {
        public async Task Tagaplaanis_Mangida(string Path)
        {
            await Task.Run(() =>
            {
                using (AudioFileReader audioFileReader = new AudioFileReader(Path))
                using (IWavePlayer waveOutDevice = new WaveOutEvent { DesiredLatency = 200 })
                {
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Play();
                    while (waveOutDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
        }
        public async Task Natuke_mangida(string Path)
        {
            await Task.Run(() =>
            {
                using (AudioFileReader audioFileReader = new AudioFileReader(Path))
                using (IWavePlayer waveOutDevice = new WaveOutEvent())
                {
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Play();
                    while (waveOutDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(50);
                    }
                }
            });
        }

    }
