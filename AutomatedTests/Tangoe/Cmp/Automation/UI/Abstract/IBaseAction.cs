using AutomatedTests.Tangoe.Cmp.Automation.Common;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract
{
    interface IBaseAction
    {
        /// <summary>
        /// Allows setting the execution mode
        /// </summary>
        /// <param name="mode">The current execution mode</param>
        void SetExecutionMode(ExecutionMode mode);
    }
}
