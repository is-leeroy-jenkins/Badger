
namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public interface ITextClassifier
    {
        /// <summary>
        /// Classifies the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        string ClassifyText(string text);
    }
}
