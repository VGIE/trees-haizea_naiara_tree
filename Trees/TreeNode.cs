
using System;
using Lists;

namespace Trees
{
    public class TreeNode<T>
    {
        private T Value;
        //TODO #1: Declare a member variable called "Children" as a list of TreeNode<T> objects
        private List<TreeNode<T>> Children;

        public TreeNode(T value)
        {
            //TODO #2: Initialize member variables/attributes
            Value = value;
            Children = new List<TreeNode<T>> ();
        }

        public string ToString(int depth, int index)
        {
            //TODO #3: Uncomment the code below

            //string output = null;
            //string leftSpace = null;
            //for (int i = 0; i < depth; i++) leftSpace += " ";
            //if (leftSpace != null) leftSpace += "->";

            //output += $"{leftSpace}[{Value}]\n";

            //for (int childIndex = 0; childIndex < Children.Count(); childIndex++)
            //{
            //    TreeNode<T> child = Children.Get(childIndex);
            //    output += child.ToString(depth + 1, childIndex);
            //}
            //return output;
            string output = null;
            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            output += $"{leftSpace}[{Value}]\n";

            for (int childIndex = 0; childIndex < Children.Count(); childIndex++)
            {
                TreeNode<T> child = Children.Get(childIndex);
                output += child.ToString(depth + 1, childIndex);
            }
            return output;
        }

        public TreeNode<T> Add(T value)
        {
            //TODO #4: Add a new instance of class GenericTreeNode<T> with Value=value. Return the instance we just created
            TreeNode<T> newNode = new TreeNode<T>(value);
            Children.Add(newNode);
            return newNode;
            
        }

        public int Count()
        {
            //TODO #5: Return the total number of elements in this tree
            int count = 1;
            for (int i = 0; i<Children.Count(); i++)
            {
                TreeNode<T> child = Children.Get(i);
                count += child.Count();
            }
            return count;
            
        }

        public int Height()
        {
            //TODO #6: Return the height of this tree
            int maxHeight = 0;
            if (Children.Count() == 0)
            {
                return 1;
            }
            for (int i = 0; i < Children.Count(); i++)
            {
                TreeNode<T> child = Children.Get(i);
                int childHeight = child.Height();
                if (childHeight > maxHeight)
                {
                    maxHeight = childHeight;
                }
            }
            return 1 + maxHeight;            
        }

        

        
        public void Remove(T value)
        {
            //TODO #7: Remove the child node that has Value=value. Apply recursively
            for (int i=0; i<Children.Count(); i++)
            {
                TreeNode<T> child = Children.Get(i);
                if (child.Value.Equals(Value))
                {
                    int numHijos = child.Children.Count();
                    if(numHijos == 0)
                    {
                        Children.Remove(i);
                        return;
                    }
                    if(numHijos == 1)
                    {
                        TreeNode<T> unicoHijo = child.Children.Get(0);
                        child.Value = unicoHijo.Value;
                        List<TreeNode<T>> nuevosHijos = new List<TreeNode<T>>();
                        for (int j=0; j<unicoHijo.Children.Count(); j++)
                        {
                            nuevosHijos.Add(unicoHijo.Children.Get(i));
                        }
                        child.Children = nuevosHijos;
                        return;
                    }
                    TreeNode<T> hijoElegido = child.Children.Get(0);
                    List<TreeNode<T>> nuevaListaHijos = new List<TreeNode<T>>();
                    for (int j=0; j<hijoElegido.Children.Count(); j++)
                    {
                        nuevaListaHijos.Add(hijoElegido.Children.Get(j));
                    }
                    for (int j=1; j<numHijos; j++)
                    {
                        TreeNode<T> otrosHijos = child.Children.Get(j);
                        nuevaListaHijos.Add(otrosHijos);
                    }
                    child.Value = hijoElegido.Value;
                    child.Children = nuevaListaHijos;
                    return;
                }
                child.Remove(value);
            }
        }

        public TreeNode<T> Find(T value)
        {
            //TODO #8: Return the node that contains this value (it might be this node or a child). Apply recursively
            
            return null;
        }


        public void Remove(TreeNode<T> node)
        {
            //TODO #9: Same as #6, but this method is given the specific node to remove, not the value
            
        }
    }
}