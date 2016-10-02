namespace _02.StringEditor.Commands
{
    using System;
    using System.Linq;

    using _02.StringEditor.Interfaces;

    [Command]
    public class Insert : ICommand
    {
        public string Execute(string @params, IStringEditor stringEditor)
        {
            var splitted = @params.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var result = stringEditor.Insert(int.Parse(splitted[0]), splitted[1])
                             ? "OK"
                             : "ERROR";

            return result;
        }
    }
}