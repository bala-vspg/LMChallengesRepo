using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace LMIChallengesCollection
{
    public interface IItem
    {
        string getName();
        int getPrice(string name);
    }


}
