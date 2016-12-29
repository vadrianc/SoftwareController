namespace SoftwareControllerLib
{
    using System.Collections.Generic;
    using SoftwareControllerApi.Action;
    using SoftwareControllerApi.Rule;

    /// <summary>
    /// Rule that can be repeated multiple times, given a custom condition.
    /// </summary>
    public class RepeatableRule : Rule, IRepeatableRule
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="RepeatableRule"/> class with the given name.
        /// </summary>
        /// <param name="name">The name of the rule.</param>
        public RepeatableRule(string name) : base(name) { }

        /// <summary>
        /// Initialize a new instance of the <see cref="RepeatableRule"/> class with the given name and collection of rules.
        /// </summary>
        /// <param name="name">The name of the rule.</param>
        /// <param name="actions">The collection of actions.</param>
        public RepeatableRule(string name, IList<IAction> actions) : base(name, actions) { }

        /// <summary>
        /// Indicates if the rule should be repeated until a certain condition is reached.
        /// </summary>
        public CanRepeatHandler CanRepeat
        {
            get;
            set;
        }
    }
}
