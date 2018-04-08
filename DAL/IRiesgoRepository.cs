using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IRiesgoRepository
    {
        IEnumerable<String> GetRiesgos();
    }
}
