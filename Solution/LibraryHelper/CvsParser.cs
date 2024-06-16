using CsvHelper;
using CsvHelper.Configuration;
using LibraryHelper.Models;
using System.Globalization;

namespace LibraryHelper
{
    public static class CvsParser
    {
        public static List<FileInput> ReadDataFromFile(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = false
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                var records = new List<FileInput>();
                while (csv.Read())
                {
                    var employeeID = csv.GetField<int>(0);
                    var projectID = csv.GetField<int>(1);
                    var startDate = DateParser.ParseDate(csv.GetField<string>(2));
                    var endDate = csv.GetField<string>(3) == "null" ? DateTime.Now : DateParser.ParseDate(csv.GetField<string>(3));

                    records.Add(new FileInput
                    {
                        EmployeeID = employeeID,
                        ProjectID = projectID,
                        StartDate = startDate,
                        EndDate = endDate
                    });
                }

                return records;
            }
        }

        public static List<FileInput> ReadDataFromFileUpload(StreamReader reader)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = false
            };

            using (var csv = new CsvReader(reader, config))
            {
                var records = new List<FileInput>();
                while (csv.Read())
                {
                    var employeeID = csv.GetField<int>(0);
                    var projectID = csv.GetField<int>(1);
                    var startDate = DateParser.ParseDate(csv.GetField<string>(2));
                    var endDate = csv.GetField<string>(3) == "null" ? DateTime.Now : DateParser.ParseDate(csv.GetField<string>(3));

                    records.Add(new FileInput
                    {
                        EmployeeID = employeeID,
                        ProjectID = projectID,
                        StartDate = startDate,
                        EndDate = endDate
                    });
                }

                return records;
            }
        }
    }
}
