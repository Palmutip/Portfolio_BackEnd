using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using VariacaoDoAtivo.Domain;

namespace VariacaoDoAtivo.Data
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ApplyGlobalConfigurations(this ModelBuilder modelBuilder)
        {
            foreach(var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach(var property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;
                        case nameof(Entity.DataAlteracao):
                            property.IsNullable = true;
                            break;
                        case nameof(Entity.DataInclusao):
                            property.IsNullable = false;
                            property.SetDefaultValue(DateTime.Now);
                            break;
                        case nameof(Entity.IsDeleted):
                            property.IsNullable = false;
                            property.SetDefaultValue(false);
                            break;
                        default:
                            break;
                    }
                }
            }

            return modelBuilder;
        }

        public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
        {
            return modelBuilder;
        }
    }
}
