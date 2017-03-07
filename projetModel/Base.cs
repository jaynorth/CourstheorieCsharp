using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetModel
{
    public abstract class Base : Object
    {
        protected string nomDeLaTable;

        public void SayCoucou()
        {
            Console.WriteLine("coucou");
        }
        public abstract string GetInfos();
    }
}
