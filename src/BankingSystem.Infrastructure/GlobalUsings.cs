﻿global using BankingSystem.Domain.Entities;
global using BankingSystem.Domain.Enums;
global using BankingSystem.Domain.Interfaces;
global using BankingSystem.Infrastructure.Entities;
global using BankingSystem.Infrastructure.Repositories;
global using BankingSystem.Infrastructure.Repositories.Base.SQLServer;
global using BankingSystem.Infrastructure.Services;
global using BankingSystem.Infrastructure.Settings;
global using Dapper;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using RandomDataGenerator.FieldOptions;
global using RandomDataGenerator.Randomizers;
global using System.Data;
global using System.Data.SqlClient;