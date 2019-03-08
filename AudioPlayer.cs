// Copyright (c) 2019 Denis Maltsev. All Rights Reserved.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;

namespace zxplayer
{
    internal class AudioPlayer
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command, StringBuilder stringReturn, int returnLength, IntPtr hwndCallback);

        private string _alias = "zxtape";
        private Timer _timer;
        private Stopwatch _playback;
        private Stopwatch _elapsed;

        public bool Playing { get; private set; }
        public bool Paused { get; private set; }
        public long Elapsed { get { return _elapsed.ElapsedMilliseconds; } }
        public long Duration { get; private set; }

        public void Play(string fileName)
        {
            Paused = false;
            Playing = true;

            ExecuteMsiCommand("Close All");
            ExecuteMsiCommand($"Open \"{fileName}\" Type MPEGVideo Alias {_alias}");
            Duration = ExecuteMsiCommand($"Status {_alias} Length");

            _timer = new Timer(Duration);
            _timer.AutoReset = false;
            _timer.Elapsed += HandleElapsed;
            _playback = new Stopwatch();
            _elapsed = new Stopwatch();

            ExecuteMsiCommand($"Play {_alias}");
            _timer.Start();
            _playback.Start();
            _elapsed.Start();
        }

        public void Pause()
        {
            if (Playing && !Paused)
            {
                ExecuteMsiCommand($"Pause {_alias}");
                Paused = true;
                _timer.Stop();
                _playback.Stop();
                _elapsed.Stop();
                _timer.Interval -= _playback.ElapsedMilliseconds;
            }
        }

        public void Resume()
        {
            if (Playing && Paused)
            {
                ExecuteMsiCommand($"Resume {_alias}");
                Paused = false;
                _timer.Start();
                _playback.Reset();
                _playback.Start();
                _elapsed.Start();
            }
        }

        public void Stop()
        {
            if (Playing)
            {
                ExecuteMsiCommand($"Close {_alias}");
                Playing = false;
                Paused = false;
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
                _playback.Stop();
                _elapsed.Stop();
            }
        }

        private void HandleElapsed(object sender, ElapsedEventArgs e)
        {
            Playing = false;
            _timer.Dispose();
            _timer = null;
            _playback.Stop();
            _elapsed.Stop();
        }

        private long ExecuteMsiCommand(string commandString)
        {
            var sb = new StringBuilder();

            var result = mciSendString(commandString, sb, 1024 * 1024, IntPtr.Zero);

            if (result != 0)
                throw new Exception($"Error executing MCI command. Error code: {result}");

            if (commandString.ToLower().StartsWith("status") && long.TryParse(sb.ToString(), out var length))
                return length;

            return 0;
        }
    }
}
