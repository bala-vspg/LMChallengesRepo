using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LMIChallengesCollection
{
    public class Customer
    {
        string name;
        List<IItem> listOfItems;

             
        public int calculateBill()
        {
            int total = 0;
            foreach(IItem item in listOfItems)
            {
                total += item.getPrice(item.getName());
            }
            return total;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public List<IItem> getListOfItems()
        {
            return listOfItems;
        }
        public void setListOfItems(List<IItem> listOfItems)
        {
            this.listOfItems = listOfItems;
        }

        

    }
    

}
