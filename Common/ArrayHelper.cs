using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Tools
{
    /// <summary>
    /// 泛型和委托的应用（跨平台、通用、方便）
    /// </summary>
    public class ArrayHelper
    {
        /// <summary>
        /// 升序
        /// </summary>
        /// <param name="array">要进行排序的数组</param>
        /// <param name="handler">要进行比较的类型</param>
        /// <typeparam name="T">类型</typeparam>
        /// <typeparam name="Tkey">在T类型中的一个类型</typeparam>
        public static void OrderBy<T,Tkey>(T[] array,SelectHandler<T,Tkey> handler)
            where Tkey:IComparable<Tkey>
        {
            //选择排序(从待排序的数组中选择最大(最小)的值放到前面）
            for (int i = 0; i < array.Length-1;i++)
            {
                for (int j = i + 1; j < array.Length;j++)
                {
                    if(handler(array[i]).CompareTo(handler(array[j]))>0)
                    {
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            ////冒泡排序(从待排序的数组中选择最大(最小)的值放到后面)
            //for (int i = 0; i < array.Length - 1;i++)
            //{
            //    for (int j = 0; j < array.Length - i - 1;j++)
            //    {
            //        if(handler(array[j]).CompareTo(handler(array[j+1]))>0)
            //        {
            //            T temp = array[j];
            //            array[j] = array[j + 1];
            //            array[j + 1] = temp;
            //        }
            //    }
            //}
            ////插入排序(把前面部分数据看成一个有序序列,之后把后面的数据插入到前面对应的下标出)
            //for (int i = 1; i < array.Length;i++)
            //{
            //    int j = i - 1;
            //    while(handler(array[j]).CompareTo(handler(array[j+1]))>0&&j>=0)
            //    {
            //        array[j+1] = array[j];
            //        j--;
            //    }
            //    array[j+1] = array[i];
            //}
        }

        /// <summary>
        /// 降序排序
        /// </summary>
        /// <param name="array">待排序的数组</param>
        /// <param name="handler">要进行排序的值</param>
        /// <typeparam name="T">类型</typeparam>
        /// <typeparam name="Tkey">T类型中的一个类型</typeparam>
        public static void OrderByDescending<T,Tkey>(T[] array,SelectHandler<T,Tkey> handler)
            where Tkey:IComparable<Tkey>
        {
            //插入排序
            for (int i = 1; i < array.Length;i++)
            {
                int j = i - 1;
                while(handler(array[j]).CompareTo(handler(array[j+1]))<0&&j>=0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = array[i];
            }
        }
        /// <summary>
        /// 找最大值
        /// </summary>
        /// <returns>The max.</returns>
        /// <param name="array">Array.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="Tkey">The 2nd type parameter.</typeparam>
        public static T Max<T,Tkey>(T[] array,SelectHandler<T,Tkey> handler)
            where Tkey:IComparable<Tkey>
        {
            T t = array[0];
            for (int i = 0; i < array.Length;i++)
            {
                if(handler(array[i]).CompareTo(handler(t))>0)
                {
                    t = array[i];
                }
            }
            return t;
        }
        /// <summary>
        /// 找出最小值
        /// </summary>
        /// <returns>The minimum.</returns>
        /// <param name="array">Array.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="Tkey">The 2nd type parameter.</typeparam>
        public static T Min<T,Tkey>(T[] array,SelectHandler<T,Tkey> handler)
            where Tkey:IComparable<Tkey>
        {
            T t = array[0];
            for (int i = 0; i < array.Length;i++)
            {
                if(handler(array[i]).CompareTo(handler(t))<0)
                {
                    t = array[i];
                }
            }
            return t;
        }
        /// <summary>
        /// 按照条件查询单个对象 例如（CharacterState 查询HP小与15的对象）
        /// </summary>
        /// <returns>The find.</returns>
        /// <param name="array">要查找的数组</param>
        /// <param name="handler">要查找的条件</param>
        /// <typeparam name="T">要查询的数组当中的类型</typeparam>
        public static T Find<T>(T[] array,FindHandler<T> handler)
        {
            for (int i = 0; i < array.Length;i++)
            {
                if(handler(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);
        }
        /// <summary>
        /// 查找所有符合条件的对象
        /// </summary>
        /// <returns>The all.</returns>
        /// <param name="array">Array.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T[]  FindAll<T>(T[] array,FindHandler<T> handler)
        {
            List<T> list = new List<T>();
            for (int i = 0; i < array.Length;i++)
            {
                if(handler(array[i]))
                {
                    list.Add(array[i]);
                }
            }
            //转化为数组
            return list.ToArray();
        }
        /// <summary>
        /// 将一个类型中的某一类型单独提取出来 例如(将Characterstate当中的HP单独提取出来)
        /// </summary>
        /// <returns>The select.</returns>
        /// <param name="array">Array.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="Tkey">The 2nd type parameter.</typeparam>
        public static Tkey[] Select<T,Tkey>(T[] array,SelectHandler<T,Tkey> handler)
        {
            Tkey[] keys = new Tkey[array.Length];
            for (int i = 0; i < array.Length;i++)
            {
                keys[i] = handler(array[i]);
            }
            return keys;
        }
        /// <summary>
        /// 根据相应的需求  选择委托
        /// <typeparam name="T">数据类型<typeparam>
        /// <typeparam name="Tkey">当前数据类型中的某种类型<typeparam name="Tkey">
        /// </summary>
        public delegate Tkey SelectHandler<T, Tkey>(T t);
        public delegate bool FindHandler<T>(T t);
    }
}
