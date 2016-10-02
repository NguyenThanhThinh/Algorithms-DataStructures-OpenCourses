namespace _02.StringEditor.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using _02.StringEditor.Interfaces;

    public class AppController : IAppController
    {
        private readonly IStringEditor stringEditor;

        public AppController(IStringEditor stringEditor)
        {
            this.stringEditor = stringEditor;
        }

        public string DispatchCommand(string commandInfo)
        {
            var commandArgs = string.Empty;
            string commandName;
            var separator = commandInfo.IndexOf(' ');
            if (separator > 0)
            {
                commandName = commandInfo.Substring(0, separator);
                commandArgs = commandInfo.Substring(
                    separator + 1,
                    commandInfo.Length - commandName.Length - 1);
            }
            else
            {
                commandName = commandInfo;
            }

            var command = this.CreateCommand(this.FormatCommandName(commandName));
            var commandResult = command.Execute(commandArgs, this.stringEditor);

            return commandResult;
        }

        private ICommand CreateCommand(string commandName)
        {
            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(type =>
                    type.CustomAttributes.Any(a => a.AttributeType == typeof(CommandAttribute)) &&
                    type.Name == commandName);

            if (commandType == null)
            {
                throw new ArgumentException("Command not implemented yet.");
            }

            var command = Activator.CreateInstance(commandType) as ICommand;

            return command;
        }

        private string FormatCommandName(string name)
        {
            name = name.ToLower();
            name = char.ToUpper(name[0]) + name.Substring(1, name.Length - 1);

            return name;
        }
    }
}