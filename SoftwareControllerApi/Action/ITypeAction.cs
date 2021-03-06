﻿namespace SoftwareControllerApi.Action
{
    /// <summary>
    /// Interface for defining an action for typing letters given an input control.
    /// </summary>
    public interface ITypeAction : ISequentialAction
    {
        /// <summary>
        /// Get the text to be typed.
        /// </summary>
        string Text { get; }
    }
}
