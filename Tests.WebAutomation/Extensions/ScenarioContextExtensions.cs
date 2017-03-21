using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace WebAutomation.Goldmine.Extensions
{
    public static class ScenarioContextExtensions
    {
        /// <summary>
        /// If no key provided, uses the class type name as key - useful for sharing a page between steps
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="value"></param>
        public static void SaveValue<T>(this ScenarioContext context, T value)
        {
            if (value.Equals(default(T)))
            {
                throw new Exception("Value cannot be default value");
            }

            var key = typeof(T).FullName;
            context.SaveValue(key, value);
        }

        public static void SaveValue<T>(this ScenarioContext context, string key, T value)
        {
            if (context.ContainsKey(key))
            {
                context[key] = value;
            }
            else
            {
                context.Add(key, value);
            }
        }

        public static T GetValue<T>(this ScenarioContext context)
        {
            var key = typeof(T).FullName;

            return context.GetValue<T>(key);
        }

        public static T GetValue<T>(this ScenarioContext context, string key)
        {
            if (!context.ContainsKey(key))
            {
                throw new ArgumentException("The key does not exist in the scenario context");
            }

            return context.Get<T>(key);
        }
    }
}
