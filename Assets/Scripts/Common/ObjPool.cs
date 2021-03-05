using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjPool<T> where T : class, new()
{
    private Queue<T> m_objectStack;
    public Func<T> init;
    public Action<T> reset;


    public ObjPool(int initialBufferSize)
    {
        m_objectStack = new Queue<T>(initialBufferSize);
    }

    public T New()
    {
        if (m_objectStack.Count > 0)
        {
            T t = m_objectStack.Dequeue();
            
            if (reset != null)
                reset(t);

            return t;
        }
        else
        {
            T t = init();
            
            return t;
        }
    }

    public void Store(T obj)
    {
        m_objectStack.Enqueue(obj);
    }
}