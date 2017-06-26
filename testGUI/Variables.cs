using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testGUI
{
    /*
    holds the variable information
    */
    public struct Variable
    {
        public int id;
        public string name;
        public string type;
        public string value;

        public Variable(int inID, string inName, string inType, string inValue)
        {
            id = inID;
            name = inName;
            type = inType;
            value = inValue;
        }
        public string getString()
        {
            return "VAR=" + id + "~" + name + "~" + type + "~" + value;
        }
    }


    class Variables
    {
        const int MAX_STRING_LENGTH = 50;
        public List<Variable> varList = new List<Variable>();
        private bool ascending = true;
        private string lastSort = "name";

        /*
        Adds a variable to the variable list, or replaces variable if matching ID is found
        */
        public void addVariable(string[] var)
        {
            int varID = int.Parse(var[0]);
            int index = varList.FindIndex(variable => variable.id == varID);
            if (var[2].Equals("bool"))
                var[3] = boolCS(var[3]);
            if (index >= 0) //found. replace value of item in list 
            {
                varList[index] = new Variable(varID, var[1], var[2], var[3]);

            }
            else //not found. add item to list.
            {
                Variable newVar = new Variable(varID, var[1], var[2], var[3]);
                varList.Add(newVar);    //add it to the list
                varList.OrderBy(variable => variable.id); //sort the list 
                Console.Write(newVar.name);
            }
        }

        /*
        converts arduino bool string to more readable format
        */
        public string boolCS(string val)
        {
            if (val.Contains("0"))
                return "false";
            else
                return "true";
        }
        /*
        returns a converted version of string bool for Arduino
        */
        public string boolAr(string val)
        {
            if (val.Equals("false"))
                return "0";
            else if(val.Equals("true"))
                return "1";
            return "0";
        }

        #region sortList

        public void sortList(string sortBy)
        {
            if (sortBy.Equals("name")) {
                decideSort("name");
            }else if (sortBy.Equals("id")){
                decideSort("id");
            }else if (sortBy.Equals("type")){
                decideSort("type");
            }else if (sortBy.Equals("value")) {
                decideSort("value");
            }else if (sortBy.Equals("bool")) {
                decideSort("bool");
            }
        }

        private void decideSort(string attribute) {
            if (lastSort.Equals(attribute)) //already sorted by this attribute
            {
                if (ascending) //list is in ascending order
                {
                    sortItem(attribute, !ascending); //sort list in descending order
                    ascending = false;
                }
                else //list is in descending order
                {
                    sortItem(attribute, !ascending); //sort list in ascending order
                    ascending = true;
                }
            }
            else //sorted by another attribute
            {
                if (ascending) //last sort was by ascending
                {
                    sortItem(attribute, ascending); //sort list in ascending order
                }
                else //last sort was by descending
                {
                    sortItem(attribute, ascending); //sort list in descending order
                }
                lastSort = attribute;
            }
        }

        private void sortItem(string attribute, bool sortAsc)
        {
            if (attribute.Equals("name"))
            {
                if(sortAsc)
                    varList.Sort((x, y) => x.name.CompareTo(y.name)); //sort list in ascending order
                else
                    varList.Sort((x, y) => y.name.CompareTo(x.name)); //sort list in ascending order
            }
            else if (attribute.Equals("id"))
            {
                if (sortAsc)
                    varList.Sort((x, y) => x.id.CompareTo(y.id)); //sort list in ascending order
                else
                    varList.Sort((x, y) => y.id.CompareTo(x.id)); //sort list in ascending order
            }
            else if (attribute.Equals("type"))
            {
                if (sortAsc)
                    varList.Sort((x, y) => x.type.CompareTo(y.type)); //sort list in ascending order
                else
                    varList.Sort((x, y) => y.type.CompareTo(x.type)); //sort list in ascending order
            }
            else if (attribute.Equals("value"))
            {
                if (sortAsc)
                    varList.Sort((x, y) => x.value.CompareTo(y.value)); //sort list in ascending order
                else
                    varList.Sort((x, y) => y.value.CompareTo(x.value)); //sort list in ascending order
            }
        }
        #endregion

        /*
        returns the list index of the item with the matching id
        */
        public int getIndex(int searchID)
        {
            var result = varList.FindIndex(x => x.id == searchID);
            return result;
        }

        /*
        takes in the index/id and returns the type of the variable
        */
        public string getType(int searchID)
        {
            var result = varList.FindIndex(x => x.id == searchID);
            return varList[result].type;
        }

        /*
        Compares the type and value to make sure that the value can
        be converted after it is written to the Arduino board

            note that Strings do have a max length
        */
        public bool validVarChange(string type, string value)
        {
            if (type.Equals("int")) //Check for valid integer
            {
                int result;
                if (int.TryParse(value, out result))
                {
                    return true;
                }
                return false;
            }else if (type.Equals("word")) //check for valid word/unsigned int
            {
                uint result;
                if (uint.TryParse(value, out result))
                {
                    return true;
                }
                return false;
            }
            else if (type.Equals("string")) //check for valid string
            {
                if (value.Length > MAX_STRING_LENGTH)
                {
                    value = value.Substring(0, MAX_STRING_LENGTH);
                }
                return true;
            }else if (type.Equals("bool")) //check for valid boolean
            {
                if (value.Equals("0") || value.Equals("1") || 
                    value.Equals("true") || value.Equals("false"))
                    return true;
                return false;
            } else if (type.Equals("char")) //check for valid char
            {
                if (value.Length > 1)
                    return false;
                return true;
            } else if (type.Equals("long")) //check for valid long
            {
                long result;
                if (long.TryParse(value, out result))
                {
                    return true;
                }
                return false;
            } else if (type.Equals("ulong")) //check for valid unsigned long
            {
                ulong result;
                if (ulong.TryParse(value, out result))
                {
                    return true;
                }
                return false;
            }  else if (type.Equals("float") || type.Equals("double")) //check for valid float/double
            {   //note that float and double are the same on the arduino platform
                float result;
                if (float.TryParse(value, out result))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
