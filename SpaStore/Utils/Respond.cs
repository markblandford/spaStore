namespace SpaStore.Utils
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>A collection of convenience methods that make it simple
    /// to throw an <see cref="IActionResult"/> from a <see cref="Controller"/>
    /// action instead of returning it.
    /// <p>There isn't a method for 500 Internal Server Error. Just
    /// throw a simple exception instead.</p>
    /// <p>See also <seealso cref="ActionResultException"/> and
    /// <seealso cref="ActionResultExceptionFilter"/>.</p></summary>
    public static class Respond
    {
        /// <summary>Throws 404 Not Found</summary>
        public static void NotFound()
        {
            With(new NotFoundResult());
        }

        /// <summary>Wraps any result in an <see cref="ActionResultException"/>
        /// and throws it.</summary>
        /// <param name="result">The result of the controller action.
        /// Usually a rejection of some kind.</param>
        public static void With(IActionResult result)
        {
            throw new ActionResultException(result);
        }
    }
}
