using System;
using System.Collections.Generic;

namespace MauiApp1
{
    public class Variable : IDisposable
    {
        /* ---------------------------------- types --------------------------------- */
        public enum CreationStatus
        {
            Success, AlreadyExistsError, AssignmentError, IllegalNameError
        }

        public record CreationResult(Variable? Variable, CreationStatus Status);

        /* --------------------------------- fields --------------------------------- */
        private VariableValidator _validator;
        private VariableRegistry _registry;

        /* ------------------------------- properties ------------------------------- */
        public VariableType Type { get; private set; }
        public string Name { get; private set; }
        public string Value { get; set; }

        /* ------------------------------ constructors ------------------------------ */
        private Variable(AppContext context, VariableType type, string name, string value)
        {
            _validator = context.VariableValidator;
            _registry = context.VariableRegistry;

            if (_validator.NameNotValid(name)) throw new IllegalVariableNameException($"{name} is incorrect");
            if (_validator.ValueNotValid(value, type)) throw new VariableAssignmentException($"{value} cannot be assigned to {type} {name}");
            if (_registry.Contains(name)) throw new VariableAlreadyExistsException("{name} is already exists");

            Name = name;
            Value = value;
            Type = type;
            _registry.Add(this);
        }

        /* --------------------------------- methods -------------------------------- */
        public static CreationResult Create(AppContext context, VariableType type, string name, string value)
        {
            try
            {
                Variable variable = new Variable(context, type, name, value);
                return new(variable, CreationStatus.Success);
            }
            catch (VariableAssignmentException) { return new(null, CreationStatus.AssignmentError); }
            catch (IllegalVariableNameException) { return new(null, CreationStatus.IllegalNameError); }
            catch (VariableAlreadyExistsException) { return new(null, CreationStatus.AlreadyExistsError); }
        }

        public void Dispose()
        {
            _registry.Remove(this);
        }

        public override string ToString() => $"{Type} {Name} {Value}";
    }
}
