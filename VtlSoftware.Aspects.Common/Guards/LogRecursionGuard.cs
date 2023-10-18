namespace VtlSoftware.Aspects.Common
{
    /// <summary>
    /// A log recursion guard.
    /// </summary>
    ///
    /// <remarks></remarks>
    ///
    public static class LogRecursionGuard
    {
        #region Fields
        /// <summary>
        /// True if is logging, false if not.
        /// </summary>
        [ThreadStatic]
        public static bool isLogging;

        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the state of the DisposeCookie 'Begin'.
        /// </summary>
        ///
        /// <remarks></remarks>
        ///
        /// <returns>A DisposeCookie.</returns>
        ///
        /// ### <remarks>.</remarks>

        public static DisposeCookie Begin()
        {
            if(isLogging)
            {
                return new DisposeCookie(false);
            } else
            {
                isLogging = true;
                return new DisposeCookie(true);
            }
        }

        #endregion

        /// <summary>
        /// A dispose cookie.
        /// </summary>
        ///
        /// <remarks></remarks>
        ///
        /// <seealso cref="T:IDisposable"/>
        ///
        /// ### <remarks>.</remarks>

        public class DisposeCookie : IDisposable
        {
            #region Constructors
            /// <summary>
            /// Constructor.
            /// </summary>
            ///
            /// <remarks></remarks>
            ///
            /// <param name="canLog">True if we can log, false if not.</param>
            ///
            /// ### <remarks>.</remarks>

            public DisposeCookie(bool canLog) { this.CanLog = canLog; }

            #endregion

            #region Public Methods
            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            ///
            /// <remarks></remarks>
            ///
            /// <seealso cref="M:IDisposable.Dispose()"/>
            ///
            /// ### <remarks>.</remarks>

            public void Dispose()
            {
                if(this.CanLog)
                {
                    isLogging = false;
                }
            }

            #endregion

            #region Public Properties
            /// <summary>
            /// Gets a value indicating whether we can log.
            /// </summary>
            ///
            /// <value>True if we can log, false if not.</value>

            public bool CanLog { get; }

            #endregion
        }
    }
}
