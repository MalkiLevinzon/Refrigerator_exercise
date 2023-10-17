using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    internal class Refrigerator
    {
        public static int UniqueId { get; set; } = 1;
        public int Id { get; } = 134;
        public string Model { get; set; }
        public string Color { get; set; }
        public List<Shelf> Shelves { get; set; }
        public int AmountOfShelves { get; set; } 

       

        public Refrigerator(string model, string color, List<Shelf> shelves)
        {
            Id += UniqueId++;
            Model = model;
            Color = color;
            Shelves = shelves;
            AmountOfShelves=Shelves.Count;
        }
        public override string ToString() => base.ToString() + "id: " + Id + " model: " + Model + " color: " + Color + " amount of shelves: " + AmountOfShelves +
             " shelves: " + Shelves;

        public int GetFreeSpace() { 
            int freeSpace = 0;
            foreach (var shelf in Shelves)
            {
                freeSpace += shelf.SpaceAvailable;
            }
            return freeSpace;
        }

        public void InsertingItem(Item item)
        {
            if (item == null) throw new Exception("invalid item");
            if (GetFreeSpace()<item.Space) throw new Exception("There is not enough space");
            foreach (var shelf in Shelves)
            {
                if (shelf.SpaceAvailable>=item.Space)
                {
                    shelf.InsertingItem(item);
                    return;
                }
                throw new Exception("There is not enough space");

            }
  
        }


        public Item TookItem(int itemId)
        {
            Item empty=null;
            foreach (var shelf in Shelves)
            {
                empty = shelf.TookItem(itemId);
                if (empty != null) return empty;    

            }
            
            return empty;
        }

        public void Cleaning()
        {
            foreach (Shelf shelf in Shelves)
            {
                shelf.Cleaning();
            }
        }


    }

}
