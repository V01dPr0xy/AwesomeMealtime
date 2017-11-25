using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMealtime.Models
{
    public class Pantry
        //Assigned to Micah Ketchum
    {
        public List<Ingredient> Food_Stuffs { get; set; }

        void Add(Ingredient ing) { Food_Stuffs.Add(ing); }
        void Remove(Ingredient ing) { Food_Stuffs.Remove(ing); }
        void Edit() { }
        void Filter() { }
        void Sort() { }
        void Expiration_Warning() { }
        void Expiration_Dispose() { }
    }
}
