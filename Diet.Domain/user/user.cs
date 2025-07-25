﻿using Diet.Domain.Case;
using Diet.Domain.common;
using Diet.Domain.Contract.Enums;
using Diet.Domain.ticket.Entities;
using System.Reflection;

namespace Diet.Domain.user.Entities;
/// <summary>
/// کاربر سیستم
/// </summary>
public sealed class User : BaseEntity
{

    private User() { }


    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    //public bool? Female { get; private set; }
    public string? ImageName { get; private set; }
    public string? ReferenceCode { get; private set; }
    public string? VerifyCode { get; private set; }
    public string? CardNumber { get; private set; }
    public string? ShbaNumber { get; private set; }
    public DateTime? VerifyExpire { get; private set; }
    public bool Deleted { get; private set; }

    public DateTime CreateDate { get; private set; }

    public DateTime? BirthDay { get; private set; }
    public Gender? Gender { get; private set; }
    public ICollection<UserRole> UserRoles { get; private set; }
    public ICollection<Ticket> Ticket { get; private set; }
    public ICollection<TicketMessage> FormTicketMessage { get; private set; }
    public ICollection<Case.Case> Case { get; private set; }
}

