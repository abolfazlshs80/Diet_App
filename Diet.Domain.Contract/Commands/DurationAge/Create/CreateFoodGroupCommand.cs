﻿

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateDurationAgeCommand(string Title) : ICommand;
 