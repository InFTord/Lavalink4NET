﻿namespace Lavalink4NET.Player
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lavalink4NET.Filters;
    using Lavalink4NET.Payloads.Player;

    public sealed class PlayerFilterMap
    {
        private readonly LavalinkPlayer _player;
        private bool _changesToCommit;

        internal PlayerFilterMap(LavalinkPlayer player)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            Filters = new Dictionary<string, IFilterOptions>();
        }

        public async Task CommitAsync(bool force = false)
        {
            if (!_changesToCommit && !force)
            {
                return;
            }

            var payload = new PlayerFiltersPayload(
                guildId: _player.GuildId,
                filters: Filters);

            await _player.LavalinkSocket
                .SendPayloadAsync(payload)
                .ConfigureAwait(false);
        }

        public VolumeFilterOptions? Volume
        {
            get => this[VolumeFilterOptions.Name] as VolumeFilterOptions;
            set => this[VolumeFilterOptions.Name] = value;
        }

        public EqualizerFilterOptions? Equalizer
        {
            get => this[EqualizerFilterOptions.Name] as EqualizerFilterOptions;
            set => this[EqualizerFilterOptions.Name] = value;
        }

        public KaraokeFilterOptions? Karaoke
        {
            get => this[KaraokeFilterOptions.Name] as KaraokeFilterOptions;
            set => this[KaraokeFilterOptions.Name] = value;
        }

        public TimescaleFilterOptions? Timescale
        {
            get => this[TimescaleFilterOptions.Name] as TimescaleFilterOptions;
            set => this[TimescaleFilterOptions.Name] = value;
        }

        public TremoloFilterOptions? Tremolo
        {
            get => this[TremoloFilterOptions.Name] as TremoloFilterOptions;
            set => this[TremoloFilterOptions.Name] = value;
        }

        public VibratoFilterOptions? Vibrato
        {
            get => this[VibratoFilterOptions.Name] as VibratoFilterOptions;
            set => this[VibratoFilterOptions.Name] = value;
        }

        public RotationFilterOptions? Rotation
        {
            get => this[RotationFilterOptions.Name] as RotationFilterOptions;
            set => this[RotationFilterOptions.Name] = value;
        }

        public DistortionFilterOptions? Distortion
        {
            get => this[DistortionFilterOptions.Name] as DistortionFilterOptions;
            set => this[DistortionFilterOptions.Name] = value;
        }

        public ChannelMixFilterOptions? ChannelMix
        {
            get => this[ChannelMixFilterOptions.Name] as ChannelMixFilterOptions;
            set => this[ChannelMixFilterOptions.Name] = value;
        }

        public LowPassFilterOptions? LowPass
        {
            get => this[LowPassFilterOptions.Name] as LowPassFilterOptions;
            set => this[LowPassFilterOptions.Name] = value;
        }

        internal Dictionary<string, IFilterOptions> Filters { get; set; }

        public IFilterOptions? this[string name]
        {
            get
            {
                return Filters.TryGetValue(name, out var options) ? options : null;
            }

            set
            {
                if (value is null)
                {
                    if (Filters.Remove(name))
                    {
                        _changesToCommit = true;
                    }

                    return;
                }

                Filters[name] = value!;
                _changesToCommit = true;
            }
        }
    }
}
