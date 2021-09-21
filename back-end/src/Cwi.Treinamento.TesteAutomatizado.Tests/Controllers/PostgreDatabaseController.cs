using Dapper;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cwi.Treinamento.TesteAutomatizado.Tests.Controllers
{
    public class PostgreDatabaseController
    {
        private readonly NpgsqlConnection _connection;

        public PostgreDatabaseController(NpgsqlConnection connection)
        {
            try 
            { 
                _connection = connection;

                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

            } 
            catch (Exception ex) 
            {
                throw new Exception("Não foi possível abrir a conexão com o banco de dados.", ex);
            }
        }

        public async Task ClearDatabase(string schema = "public") 
        {
            var query = @$"DO
                          $$
                          DECLARE
                            l_stmt VARCHAR;
                            databaseschema VARCHAR:= '{schema}';
                          BEGIN
                            SELECT 'truncate ' || string_agg(format('%I.%I', schemaname, tablename), ',')
                            INTO l_stmt
                            FROM pg_tables
                            WHERE schemaname = databaseschema;
                            
                            EXECUTE l_stmt || ' RESTART IDENTITY';
                          END
                          $$";

            await _connection.ExecuteAsync(query);
        }

        public async Task InsertIntoTable(string tableName, Table table) 
        {
            var insertColumns = string.Join(",", GetColumns(table));
            var insertValues = string.Join(",", GetInsertValues(table));

            var query = $"INSERT INTO {tableName} ({insertColumns}) VALUES {insertValues}";

            await _connection.ExecuteAsync(query);
        }

        private string[] GetColumns(Table table)
        {
            return table.Header.ToArray();
        }

        private string[] GetInsertValues(Table table)
        {
            var insertValues = new List<string>();

            for (int row = 0; row < table.RowCount; row++)
            {
                var rowValues = new List<string>();

                for (int header = 0; header < table.Header.Count; header++)
                {
                    string value = table.Rows[row][header];

                    rowValues.Add($"{value}");
                }

                insertValues.Add($"({string.Join(",", rowValues)})");
            }

            return insertValues.ToArray();
        }

        public async Task<IEnumerable<object>> SelectFrom(string tableName, Table table)
        {
            var selectColumns = string.Join(",", GetColumnsForSelect(table));
            var filterConditions = string.Join(" OR ", GetFilterConditions(table));

            var query = $"SELECT {selectColumns} FROM {tableName} WHERE {filterConditions}";

            return await _connection.QueryAsync(query);
        }

        private string [] GetFilterConditions(Table table)
        {
            var filters = new List<string>();

            for (int row = 0; row < table.RowCount; row++) 
            {
                var rowConditions = new List<string>();

                for (int header = 0; header < table.Header.Count; header ++)
                {
                    string column = table.Header.ElementAt(header);
                    string value = table.Rows[row][header];


                    rowConditions.Add($"{column} = {value}");
                }

                filters.Add($"({string.Join(" AND ", rowConditions)})");
            }

            return filters.ToArray(); 
        }

        private string [] GetColumnsForSelect(Table table)
        {
            return table.Header.Select(s => $"{s} as \"{s}\"").ToArray();
        }
    }
}
