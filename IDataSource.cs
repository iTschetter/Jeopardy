using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    public interface IDataSource
    {
        IEnumerable<Question> Questions { get; }
    }
}
