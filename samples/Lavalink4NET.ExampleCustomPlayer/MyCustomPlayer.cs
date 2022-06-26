/*
 *  File:   MyCustomPlayer.cs
 *  Author: Angelo Breuer
 *
 *  The MIT License (MIT)
 *
 *  Copyright (c) Angelo Breuer 2022
 *
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in
 *  all copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 *  THE SOFTWARE.
 */

namespace Lavalink4NET.ExampleCustomPlayer
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lavalink4NET.Player;

    /// <summary>
    ///     A custom player that saves the last used volume.
    /// </summary>
    public sealed class MyCustomPlayer : LavalinkPlayer
    {
        /// <summary>
        ///     The dictionary holding the last used volumes.
        /// </summary>
        /// <remarks>
        ///     This can be replaced with a database or something else to keep the values persistent.
        /// </remarks>
        private readonly static IDictionary<ulong, float> _volumes = new Dictionary<ulong, float>();

        /// <summary>
        ///     Updates the player volume asynchronously.
        /// </summary>
        /// <param name="volume">the player volume (0f - 10f)</param>
        /// <param name="normalize">
        ///     a value indicating whether if the <paramref name="volume"/> is out of range (0f -
        ///     10f) it should be normalized in its range. For example 11f will be mapped to 10f and
        ///     -20f to 0f.
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        /// <exception cref="InvalidOperationException">
        ///     thrown if the player is not connected to a voice channel
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     thrown if the specified <paramref name="volume"/> is out of range (0f - 10f)
        /// </exception>
        /// <exception cref="InvalidOperationException">thrown if the player is destroyed</exception>
        public override async Task SetVolumeAsync(float volume = 1, bool normalize = false)
        {
            EnsureNotDestroyed();
            EnsureConnected();

            // call the base method, without using it the volume would remain the same.
            await base.SetVolumeAsync(volume, normalize);

            // store the volume of the player
            _volumes[GuildId] = volume;
        }

        /// <summary>
        ///     Asynchronously triggered when the player has connected to a voice channel.
        /// </summary>
        /// <param name="voiceServer">the voice server connected to</param>
        /// <param name="voiceState">the voice state</param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public async override Task OnConnectedAsync(VoiceServer voiceServer, VoiceState voiceState)
        {
            // check if a volume has been stored
            if (_volumes.TryGetValue(GuildId, out var volume) && Volume != volume)
            {
                // here the volume is restored
                await SetVolumeAsync(volume);
            }

            await base.OnConnectedAsync(voiceServer, voiceState);
        }
    }
}
