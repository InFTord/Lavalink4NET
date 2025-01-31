/*
 *  File:   AsyncEventHandler.cs
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

namespace Lavalink4NET.Events;

using System;
using System.Threading.Tasks;

/// <summary>
///     An asynchronous event handler.
/// </summary>
/// <typeparam name="TEventArgs">the type of the event arguments</typeparam>
/// <param name="sender">the object that fired the event</param>
/// <param name="eventArgs">the event arguments</param>
/// <returns>a task that represents the asynchronous operation</returns>
public delegate Task AsyncEventHandler<TEventArgs>(object sender, TEventArgs eventArgs);

/// <summary>
///     An asynchronous event handler.
/// </summary>
/// <param name="sender">the object that fired the event</param>
/// <param name="eventArgs">the event arguments</param>
/// <returns>a task that represents the asynchronous operation</returns>
public delegate Task AsyncEventHandler(object sender, EventArgs eventArgs);
