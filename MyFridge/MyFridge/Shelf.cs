using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    internal class Shelf
    {
        public static int UniqueId { get; set; } = 1;
        public int Id { get; }
        public int FloorNumber { get; }
        private int _spaceAvailable;

        public int SpaceAvailable
        {
            get => _spaceAvailable; set
            {
                if (value <= 0)
                {
                    throw new Exception("There is no space");
                }

                _spaceAvailable = value;
            }
        }
        public List<Item> Items { get; }       
      

        public Shelf(int floorNumber, List<Item> items )
        {
            
            Id += UniqueId++;
            
            FloorNumber = floorNumber;
            if (items!=null)
            {
            foreach (var item in items)
            {
                if (item == null) items.Remove(item);
            }
            Items = items;
        }}
        public override string ToString() =>Id
            .ToString()+FloorNumber.ToString()+SpaceAvailable.ToString()+Items.Count.ToString();


        public void InsertingItem(Item item)
        {
            if (item!=null&&SpaceAvailable>=item.Space)
            {
                Items.Add(item);
                SpaceAvailable-=item.Space;

            }
        }
        public Item TookItem(int itemId)
        {
            Item item = null;
            foreach (Item item2 in Items)
            {
                if (item2.Id == itemId)
                {
                    item = item2;
                    _spaceAvailable -= item2.Space;
                    return item;
                }
            }
            return item;
        }

        public void Cleaning()
        {
            foreach (Item item in Items)
            {
                if (item.ExpiryDate<DateTime.Now) { 
                    Items.Remove(item);
                    _spaceAvailable-=item.Space;
                }
            }


        }

    }

}
