using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testGUI
{
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

        public List<Variable> varList = new List<Variable>();

       

        /*
        Adds a variable to the variable list, or replaces variable if matching ID is found
        */
        public void addVariable(string[] var)
        {
            int varID = int.Parse(var[0]);
            int index = varList.FindIndex(variable => variable.id == varID);
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
            }
            else if (type.Equals("string"))
            {
                if (value.Length > 50)
                {
                    value = value.Substring(0, 50);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
