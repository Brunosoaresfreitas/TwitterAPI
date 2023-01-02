﻿using MediatR;

namespace Twitter.Application.Commands.UsersCommands.UpdateUserAccount
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
