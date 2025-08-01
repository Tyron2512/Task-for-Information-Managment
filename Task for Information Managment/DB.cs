using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace Task_for_Information_Managment
{
    class DB
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=scanner_inventory;Username=postgres;Password=yourpassword";

        // Expose connection string
        public string GetConnectionString()
        {
            return connectionString;
        }

        // Получение списка сканеров
        public List<Scanner> GetScanners()
        {
            List<Scanner> scanners = new List<Scanner>();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM scanners", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        scanners.Add(new Scanner
                        {
                            Id = reader.GetInt32(0),
                            InventoryNumber = reader.GetString(1),
                            Model = reader.GetString(2),
                            SerialNumber = reader.IsDBNull(3) ? null : reader.GetString(3),
                            DateRegistered = reader.GetDateTime(4),
                            DateInUse = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5),
                            AmortizationTerm = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6),
                            Condition = reader.IsDBNull(7) ? null : reader.GetString(7),
                            LocationId = reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                            EmployeeId = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9)
                        });
                    }
                }
            }
            return scanners;
        }

        // Добавление сканера
        public void AddScanner(Scanner scanner)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO scanners (inventory_number, model, serial_number, date_registered, date_in_use, amortization_term, condition, location_id, employee_id) " +
                    "VALUES (@inv, @model, @sn, @reg, @use, @amort, @cond, @loc, @emp)", conn))
                {
                    cmd.Parameters.AddWithValue("inv", scanner.InventoryNumber);
                    cmd.Parameters.AddWithValue("model", scanner.Model);
                    cmd.Parameters.AddWithValue("sn", scanner.SerialNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("reg", scanner.DateRegistered);
                    cmd.Parameters.AddWithValue("use", scanner.DateInUse ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("amort", scanner.AmortizationTerm ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("cond", scanner.Condition ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("loc", scanner.LocationId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("emp", scanner.EmployeeId ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Обновление сканера
        public void UpdateScanner(Scanner scanner)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(
                    "UPDATE scanners SET inventory_number = @inv, model = @model, serial_number = @sn, date_registered = @reg, " +
                    "date_in_use = @use, amortization_term = @amort, condition = @cond, location_id = @loc, employee_id = @emp WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", scanner.Id);
                    cmd.Parameters.AddWithValue("inv", scanner.InventoryNumber);
                    cmd.Parameters.AddWithValue("model", scanner.Model);
                    cmd.Parameters.AddWithValue("sn", scanner.SerialNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("reg", scanner.DateRegistered);
                    cmd.Parameters.AddWithValue("use", scanner.DateInUse ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("amort", scanner.AmortizationTerm ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("cond", scanner.Condition ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("loc", scanner.LocationId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("emp", scanner.EmployeeId ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Удаление сканера
        public void DeleteScanner(int id)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM scanners WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Получение списка сотрудников
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM employees", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            Id = reader.GetInt32(0),
                            FullName = reader.GetString(1),
                            Position = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                            Phone = reader.IsDBNull(4) ? null : reader.GetString(4)
                        });
                    }
                }
            }
            return employees;
        }

        // Получение списка мест
        public List<Location> GetLocations()
        {
            List<Location> locations = new List<Location>();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM locations", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        locations.Add(new Location
                        {
                            Id = reader.GetInt32(0),
                            RoomName = reader.GetString(1),
                            Building = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Floor = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3)
                        });
                    }
                }
            }
            return locations;
        }

        // Получение списка ремонтов
        public List<Repair> GetRepairs()
        {
            List<Repair> repairs = new List<Repair>();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM repairs", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        repairs.Add(new Repair
                        {
                            Id = reader.GetInt32(0),
                            ScannerId = reader.GetInt32(1),
                            RepairDate = reader.GetDateTime(2),
                            IssueDescription = reader.GetString(3),
                            RepairStatus = reader.IsDBNull(4) ? null : reader.GetString(4)
                        });
                    }
                }
            }
            return repairs;
        }

        // Добавление ремонта
        public void AddRepair(Repair repair)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO repairs (scanner_id, repair_date, issue_description, repair_status) " +
                    "VALUES (@sid, @date, @desc, @status)", conn))
                {
                    cmd.Parameters.AddWithValue("sid", repair.ScannerId);
                    cmd.Parameters.AddWithValue("date", repair.RepairDate);
                    cmd.Parameters.AddWithValue("desc", repair.IssueDescription);
                    cmd.Parameters.AddWithValue("status", repair.RepairStatus ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Формирование отчета
        public DataTable GetReport(string query)
        {
            DataTable dt = new DataTable();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var adapter = new NpgsqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}