using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Item
    {
        int itemNumber;
        string itemDescription;

        public Item(int itemNumber, string itemDescription) { 
            this.itemNumber = itemNumber;
            this.itemDescription = itemDescription;
        }

        private int getItemNumber()
        { 
            return itemNumber;
        }

        private string getItemDescription()
        { 
            return itemDescription;
        }
    }
}
