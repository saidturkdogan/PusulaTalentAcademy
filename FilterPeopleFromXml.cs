namespace PusulaTalentAcademyDocumentCandidate;

using System;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;
using System.Globalization;

public class FilterPeopleFromXmlClass
{
    public static string FilterPeopleFromXml(string xmlData)
    {
        XDocument doc = XDocument.Parse(xmlData);
        
        var people = doc.Descendants("Person")
            .Select(p => new
            {
                Name = (string)p.Element("Name"),
                Age = (int)p.Element("Age"),
                Department = (string)p.Element("Department"),
                Salary = (int)p.Element("Salary"),
                HireDate = DateTime.Parse((string)p.Element("HireDate"), CultureInfo.InvariantCulture)
            })
            .Where(p => p.Age > 30
                        && p.Department == "IT"
                        && p.Salary > 5000
                        && p.HireDate < new DateTime(2019, 1, 1))
            .ToList();
        
        var names = people.Select(p => p.Name).OrderBy(n => n).ToList();
        int totalSalary = people.Any() ? people.Sum(p => p.Salary) : 0;
        int averageSalary = people.Any() ? (int)people.Average(p => p.Salary) : 0;
        int maxSalary = people.Any() ? people.Max(p => p.Salary) : 0;
        int count = people.Count;
        
        var result = new
        {
            Names = names,
            TotalSalary = totalSalary,
            AverageSalary = averageSalary,
            MaxSalary = maxSalary,
            Count = count
        };
        
        return JsonSerializer.Serialize(result);
    }

    /* public static void Main()
    {
        string input1 = "<People><Person><Name>Ali</Name><Age>35</Age><Department>IT</Department><Salary>6000</Salary><HireDate>2018-06-01</HireDate></Person><Person><Name>Ayşe</Name><Age>28</Age><Department>HR</Department><Salary>4500</Salary><HireDate>2020-04-15</HireDate></Person></People>";
        Console.WriteLine("Çıkış 1 : " + FilterPeopleFromXml(input1));
        
        string input2 = "<People><Person><Name>Mehmet</Name><Age>40</Age><Department>IT</Department><Salary>7500</Salary><HireDate>2017-02-01</HireDate></Person></People>";
        Console.WriteLine("Çıkış 2 : " + FilterPeopleFromXml(input2));
        
        string input3 = "<People><Person><Name>Zeynep</Name><Age>45</Age><Department>IT</Department><Salary>9000</Salary><HireDate>2010-01-10</HireDate></Person><Person><Name>Ahmet</Name><Age>50</Age><Department>IT</Department><Salary>8000</Salary><HireDate>2015-05-20</HireDate></Person></People>";
        Console.WriteLine("Çıkış 3 : " + FilterPeopleFromXml(input3));
        
        string input4 = "<People><Person><Name>Fatma</Name><Age>33</Age><Department>Finance</Department><Salary>6000</Salary><HireDate>2018-11-01</HireDate></Person></People>";
        Console.WriteLine("Çıkış 4 : " + FilterPeopleFromXml(input4));
        
        string input5 = "<People><Person><Name>Selim</Name><Age>32</Age><Department>IT</Department><Salary>5500</Salary><HireDate>2018-08-05</HireDate></Person></People>";
        Console.WriteLine("Çıkış 5 : " + FilterPeopleFromXml(input5));
    } */
}
