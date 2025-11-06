namespace Lists;

//TODO #1: Copy your List<T> class (List.cs) to this project and overwrite this file.
using Lists;
using System.Collections;
using System.Threading;
using System.Xml;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;
    public ListNode<T> Pre = null;

    

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;
    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list

        return m_numItems;
        
    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds
        ListNode<T> node = First;

        if (index < 0 || index>=m_numItems)
        {
            return default(T);
        }

        for (int i = 0; i < index; i++)
        {
            node = node.Next;
        }

        return node.Value;
        
    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list
        ListNode<T> anadir = new ListNode<T>(value);

        if (Last != null)
        {
            Last.Next = anadir;
            anadir.Pre=Last;
            Last = Last.Next;
        }
        else
        {
            Last = anadir;
            First = anadir;
        }
        m_numItems++;
        
    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds
        ListNode<T> node = First;
        if (index < 0 || index >= m_numItems)
        {
            return default(T);
        }

        T elementoEliminado;

        if (index == 0 && First.Next != null)
        {
            elementoEliminado = First.Value;
            First = First.Next;
            m_numItems--;
            return elementoEliminado;
        }
        else if (index == 0 && First.Next == null)
        {
            elementoEliminado = First.Value;
            First = null;
            Last = null;
            m_numItems--;
            return elementoEliminado;
        }

        if (index == Count() - 1)
        {
            elementoEliminado = Last.Value;
            ListNode<T> TPre = Last.Pre;
            TPre.Next = null;
            Last = TPre;
            m_numItems--;
            return elementoEliminado;
        }

        for (int i = 0; i < index - 1; i++)
        {
            node = node.Next;
        }

        ListNode<T> TEliminado = node.Next;
        elementoEliminado = TEliminado.Value;
        node.Next = TEliminado.Next;


        if (TEliminado == Last)
        {
            Last=node;
        }

        m_numItems--;
        return elementoEliminado;
        
    }

    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        First = null;
        Last=null;
        m_numItems = 0;
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
        ListNode<T> node = First; 
        while (node != null)
        {
            yield return node.Value;
            node = node.Next;
        } 
        
    }
}