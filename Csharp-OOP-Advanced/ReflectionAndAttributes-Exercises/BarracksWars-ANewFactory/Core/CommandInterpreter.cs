using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider provider;

        public CommandInterpreter(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(x => x.Name.ToLower() == commandName + "command");

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command name!");
            }

            FieldInfo[] fieldsToInject = commandType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(InjectAttribute))).ToArray();

            object[] injectArgs = fieldsToInject.Select(x => this.provider.GetService(x.FieldType)).ToArray();
            
            return (IExecutable)Activator.CreateInstance(commandType, new object[] { data}.Concat(injectArgs).ToArray());
        }
    }
}
