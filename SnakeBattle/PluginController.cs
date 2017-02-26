using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using PluginInterface;

namespace SnakeBattle
{
	public static class PluginController
	{
        public static List<ISmartSnake> LoadPlugins()
        {
            var brains = new List<ISmartSnake>();

            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll"))
            {
                var name = AssemblyName.GetAssemblyName(file);
                var assembly = Assembly.Load(name);
                var type = typeof(ISmartSnake);

                foreach (var t in assembly.GetTypes())
                {
                    if (t.GetInterface(type.FullName) != null)
                    {
                        brains.Add(Activator.CreateInstance(t) as ISmartSnake);
                    }
                }
            }

            return brains;
        }
    }
}
