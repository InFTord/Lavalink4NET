/*
 *  File:   VoiceUpdatePayload.cs
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

namespace Lavalink4NET.Payloads.Node;

using System.Text.Json.Serialization;
using Lavalink4NET.Converters;
using Lavalink4NET.Payloads.Events;

/// <summary>
///     The representation of a voice update lavalink payload.
/// </summary>
public sealed class VoiceUpdatePayload
{
    /// <summary>
    ///     Gets the guild snowflake identifier the voice update is for.
    /// </summary>
    [JsonPropertyName("guildId")]
    [JsonConverter(typeof(UInt64AsStringJsonSerializer))]
    public ulong GuildId { get; init; }

    /// <summary>
    ///     Gets the discord voice state session identifier received from the voice state update payload.
    /// </summary>
    [JsonPropertyName("sessionId")]
    public string SessionId { get; init; } = null!;

    /// <summary>
    ///     Gets the voice server update event.
    /// </summary>
    [JsonPropertyName("event")]
    public VoiceServerUpdateEvent VoiceServerUpdateEvent { get; init; } = null!;
}
