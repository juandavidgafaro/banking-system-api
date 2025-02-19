﻿namespace BankingSystem.Api.Application.Commands;
public class WithdrawTransactionCommand : IRequest<Guid>
{
    public int ProductId { get; set; }
    public HeaderRequestModel Header { get; set; }
    public MakeWithdrawDTO Body { get; set; }
}