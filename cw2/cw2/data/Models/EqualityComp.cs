using System;
using System.Collections.Generic;
using System.Text;

namespace cw2.data.Models
{
    class EqualityComp : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return x.index == y.index && x.Imie==y.Imie && x.Nazwisko == y.Nazwisko ;
        }

        public int GetHashCode(Student obj)
        {
            return obj.index.GetHashCode();
        }
    }
}
