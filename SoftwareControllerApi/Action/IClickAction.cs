﻿namespace SoftwareControllerApi.Action
{
    using System;

    /// <summary>
    /// Interface for defining an action related to clicking the button of a mouse.
    /// </summary>
    public interface IClickAction : ISequentialAction
    {
        /// <summary>
        /// Get the item to be clicked.
        /// </summary>
        Object Item { get; }
    }
}
