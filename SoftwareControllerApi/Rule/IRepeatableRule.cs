namespace SoftwareControllerApi.Rule
{
    /// <summary>
    /// Signature of the delegate for a method which indicates if a rule can be repeated or not.
    /// </summary>
    /// <returns></returns>
    public delegate bool CanRepeatHandler();

    /// <summary>
    /// Interfaces for defining a rule which can be executed multiple times.
    /// </summary>
    public interface IRepeatableRule
    {
        /// <summary>
        /// Indicates if the rule should be repeated until a certain condition is reached.
        /// </summary>
        /// <returns><c>true</c> if the rule can be repeated, <c>false</c> otherwise.</returns>
        CanRepeatHandler CanRepeat
        {
            get;
            set;
        }
    }
}
