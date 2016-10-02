namespace _02.StringEditor.Commands
{
    using System;
    using System.Linq;

    using _02.StringEditor.Interfaces;

    [Command]
    public class Delete : ICommand
    {
        public string Execute(string @params, IStringEditor stringEditor)
        {
            var splitted = @params.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            return stringEditor.Delete(splitted[0], splitted[1]) ? "OK" : "ERROR";
        }
    }
}