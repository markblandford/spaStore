namespace SpaStore.Utils
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>Allows us to throw an <see cref="IActionResult"/> from a
    /// <see cref="Controller"/> action. Typically used to handle 400 codes
    /// such as NotFound and BadRequest.
    /// </summary>
    public class ActionResultException : Exception
    {
        /// <summary>Wraps an action result.</summary>
        /// <param name="result">The result of the controller action.</param>
        public ActionResultException(IActionResult result)
        {
            Result = result;
        }

        /// <summary>The result of the <see cref="Controller"/> action.</summary>
        public IActionResult Result { get; }
    }
}